using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ChangeScene(int scene)
	{
		Debug.Log("Changing!");
		SceneManager.LoadScene(scene);
	}
	public void Exit()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

}
