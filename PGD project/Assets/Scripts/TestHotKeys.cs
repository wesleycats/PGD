using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestHotKeys : MonoBehaviour {

	public KeyCode restart;

	void Update () {
		if (Input.GetKeyDown(restart))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
