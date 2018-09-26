using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject closedRoom;
	public GameObject[] topRooms;
	public GameObject[] bottomRooms;
	public GameObject[] rightRooms;
	public GameObject[] leftRooms;

	public List<GameObject> rooms = new List<GameObject>();
	public bool spawnedBoss;
	public GameObject boss;
	public float bossSpawnTime = 2f;
	public float roomSpawnTime = 0.5f;

	/// <summary>
	/// Spawns endroom with boss after x amount of seconds
	/// </summary>
	void Update()
	{
		if (bossSpawnTime <= 0 && !spawnedBoss)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		}
		else
		{
			bossSpawnTime -= Time.deltaTime;
		}
	}
}
