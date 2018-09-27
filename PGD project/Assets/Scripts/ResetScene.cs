using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButton(0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
