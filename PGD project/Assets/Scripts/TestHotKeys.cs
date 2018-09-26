using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestHotKeys : MonoBehaviour {

	public KeyCode reset = KeyCode.R;

	void Update () {
		if (Input.GetKeyDown(reset))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
