using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	RoomTemplates templates;

	/// <summary>
	/// Adds room to a list to keep track of which rooms are spawned
	/// </summary>
	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
	}
}
