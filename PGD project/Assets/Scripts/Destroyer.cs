using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	/// <summary>
	/// To destroy any room that spawns on top of the TBRL (all directions) room
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
