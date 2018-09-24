using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public char openingDirection;
	// T --> top
	// B --> bottom
	// R --> right
	// L --> left

	[SerializeField] private RoomTemplates templates;
	private int rand;
	[SerializeField] private bool spawned = false;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Log();
		Invoke("Spawn", 0.1f);
	}

	void Spawn()
	{
		if (spawned) return;
		switch (openingDirection)
		{
			case 'T':
				// spawn room with top door
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
				break;

			case 'B':
				// spawn room with bot door
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
				break;

			case 'R':
				// spawn room with right door
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
				break;

			case 'L':
				// spawn room with left door
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
				break;

			default:
					print("There was no opening direction given");
				break;
		}
		/*
		if (openingDirection == 'T')
		{
			rand = Random.Range(0, templates.topRooms.Length);
			Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
		}
		else if (openingDirection == 'B')
		{
			rand = Random.Range(0, templates.bottomRooms.Length);
			Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
		}
		else if (openingDirection == 'R')
		{
			rand = Random.Range(0, templates.rightRooms.Length);
			Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
		}
		else if (openingDirection == 'L')
		{
			rand = Random.Range(0, templates.leftRooms.Length);
			Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
		}*/
		spawned = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("SpawnPoint")) return;

		try
		{
			if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
		catch
		{
			Debug.Log(transform.parent.name + " " + transform.position + " " + other.transform.parent.name + " " + other.transform.position);
			Debug.Log(templates);
		}
		
		spawned = true;
	}

	void Log()
	{
		Debug.Log(transform.position);
		Debug.Log(templates);
		Debug.Log(templates.closedRoom);
	}
}
