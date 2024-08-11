using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
	public Button[] buttons;

	private void Awake()
	{
		if (buttons == null || buttons.Length == 0)
		{
			Debug.LogError("Buttons array is not assigned or is empty.");
			return;
		}

		int unlockedLevel = PlayerPrefs.GetInt("Unlocked level", 1);

		// Set all buttons to be non-interactable
		for (int i = 0; i < buttons.Length; i++)
		{
			if (buttons[i] != null)
			{
				buttons[i].interactable = false;
			}
			else
			{
				Debug.LogError($"Button at index {i} is not assigned.");
			}
		}

		// Set buttons up to unlockedLevel to be interactable
		for (int i = 0; i < unlockedLevel && i < buttons.Length; i++)
		{
			if (buttons[i] != null)
			{
				buttons[i].interactable = true;
			}
		}
	}

	public void OpenLevel(int levelId)
	{
		string levelName = "level" + levelId;
		SceneManager.LoadScene(levelName);
	}
}
