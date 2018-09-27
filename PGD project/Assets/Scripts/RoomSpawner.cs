using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RoomSpawner script that goes on every spawnpoint
/// </summary>
public class RoomSpawner : MonoBehaviour {

	public char openingDirection;
	// T --> top
	// B --> bottom
	// R --> right
	// L --> left

	public int directionAmount = 4;
	public List<char> openingDirections = new List<char>();

	[SerializeField] private RoomTemplates templates;
	[SerializeField] private bool spawned = false;
	[SerializeField] private Vector2 roomSize = new Vector2(10f, 10f);

	private float spawnWaitTime;
	private IEnumerator coroutine;
	private int rand;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		spawnWaitTime = templates.roomSpawnTime;
		openingDirections.Add('T');
		openingDirections.Add('B');
		openingDirections.Add('R');
		openingDirections.Add('L');

		if (!isNextInView(transform.position))
		{
			openingDirection = GetOtherOpening(openingDirection, openingDirections);
		}

		if (!isNextInView(transform.position))
		{
			Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
			return;
		}

		coroutine = Spawn(transform.position, spawnWaitTime, openingDirection);
		StartCoroutine(coroutine);
	}

	/// <summary>
	/// Spawns a random room at this spawnpoint position
	/// </summary>
	/// <param name="position"></param>
	/// <param name="waitTime"></param>
	/// <param name="currentDirection"></param>
	/// <returns></returns>
	IEnumerator Spawn(Vector2 position, float waitTime, char currentDirection)
	{
		yield return new WaitForSeconds(waitTime);

		if (spawned) yield break;

		switch (currentDirection)
		{
			case 'T':
				// spawn room with atleast a top door
				rand = Random.Range(0, templates.topRooms.Length);
				GameObject room = templates.topRooms[rand];
				Instantiate(room, position, Quaternion.identity);
				break;

			case 'B':
				// spawn room with atleast a bot door
				rand = Random.Range(0, templates.bottomRooms.Length);
				room = templates.bottomRooms[rand];
				Instantiate(room, position, Quaternion.identity);
				break;

			case 'R':
				// spawn room with atleast a right door
				rand = Random.Range(0, templates.rightRooms.Length);
				room = templates.rightRooms[rand];
				Instantiate(room, position, Quaternion.identity);
				break;

			case 'L':
				// spawn room with atleast a left door
				rand = Random.Range(0, templates.leftRooms.Length);
				room = templates.leftRooms[rand];
				Instantiate(room, position, Quaternion.identity);
				break;

			default:
					print("There was no opening direction given");
				break;
		}
		spawned = true;
	}

	/// <summary>
	/// The trigger ensures that there wont be open exits
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("SpawnPoint")) return;

		if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
		{
			Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		spawned = true;
	}

	/// <summary>
	/// Checks if the next room will be at the border
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public bool isNextInView(float x, float y)
	{
		Vector2 cameraDimensions = new Vector2(0,0);
		if (x < 0 && y < 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x - roomSize.x, y - roomSize.y));
		}
		else if (x < 0 && y > 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x - roomSize.x, y + roomSize.y));
		}
		else if (x > 0 && y < 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x + roomSize.x, y - roomSize.y));
		}
		else if (x > 0 && y > 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x + roomSize.x, y + roomSize.y));
		}
		else if (x < 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x - roomSize.x, y));
		}
		else if (x > 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x + roomSize.x, y));
		}
		else if (y < 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x, y - roomSize.y));
		}
		else if (y > 0)
		{
			cameraDimensions = Camera.main.WorldToViewportPoint(new Vector2(x, y + roomSize.y));
		}

		return (cameraDimensions.x > 0 && cameraDimensions.x < 1 && cameraDimensions.y > 0 && cameraDimensions.y < 1);
	}

	/// <summary>
	/// Checks if the next room will be at the border
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	public bool isNextInView(Vector2 position)
	{
		return (isNextInView(position.x, position.y));
	}

	/// <summary>
	/// Get another opening direction if against the border
	/// </summary>
	/// <param name="currentOpening"></param>
	/// <param name="openingDirections"></param>
	/// <returns></returns>
	public char GetOtherOpening(char currentOpening, List<char> openingDirections)
	{
		char newOpening = openingDirections[Random.Range(0, openingDirections.Count)];

		while (newOpening == currentOpening)
		{
			newOpening = openingDirections[Random.Range(0, openingDirections.Count)];
		}

		return newOpening;
	}
	
}
