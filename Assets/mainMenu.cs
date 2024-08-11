using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
	public void playGame()
	{
		SceneManager.LoadSceneAsync(1);
	}
	public void quitGame()
	{
		Debug.Log("PLAYER QUITS THE GAME");
	}

}