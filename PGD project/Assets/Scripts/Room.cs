using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {

	public Vector2 gridPos;
	public Vector2 size;
	public int type;
	public bool doorTop, doorBot, doorRight, doorLeft;

	public Room(Vector2 _gridPos, Vector2 _size, int _type) {
		gridPos = _gridPos;
		type = _type;
		size = _size;
	}
}
