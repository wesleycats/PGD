﻿using System.Collections;
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

	public float waitTime;

	void Update()
	{
		if (waitTime <= 0 && !spawnedBoss)
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
			waitTime -= Time.deltaTime;
		}
	}
}
