////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;
////using UnityEngine.SceneManagement; // Needed for scene management

////public class GameManager : MonoBehaviour
////{
////	public static GameManager instance; // Singleton instance
////	private int enemiesDestroyed = 0; // Count of destroyed enemies
////	public int totalEnemies = 3; // Total number of enemies to be destroyed to win
////	public Transform crystalTransform; // Reference to the crystal transform
////	public GameObject winPanel; // Reference to the win panel

////	void Awake()
////	{
////		// Ensure there's only one instance of GameManager
////		if (instance == null)
////		{
////			instance = this;
////			DontDestroyOnLoad(gameObject); // Optional: Keep the GameManager across scenes
////		}
////		else
////		{
////			Destroy(gameObject);
////		}
////	}

////	public void EnemyDestroyed()
////	{
////		enemiesDestroyed++;

////		Debug.Log("Enemies destroyed: " + enemiesDestroyed);

////		if (enemiesDestroyed >= totalEnemies)
////		{
////			EndGame();
////		}
////	}

////	void EndGame()
////	{

////		if (winPanel != null)
////		{
////			winPanel.SetActive(true);
////			//Debug.Log("Win panel activated.");
////		}

////		// Game ko pause karein
////		Time.timeScale = 0f;


////		Debug.Log("You win, all enemies destroyed!");


////	}

////	// Method to restart the game
////	public void RestartGame()
////	{
////		Time.timeScale = 1f; // Resume game time
////		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
////	}

////	// Method to go to the main menu
////	public void GoToMainMenu()
////	{
////		Time.timeScale = 1f; // Resume game time
////		SceneManager.LoadScene(0); // Replace "MainMenu" with the name of your main menu scene
////	}
////	public void UnlockNewLevel()
////	{
////		int currentIndex = SceneManager.GetActiveScene().buildIndex;
////		int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);

////		if (currentIndex >= reachedIndex)
////		{
////			PlayerPrefs.SetInt("ReachedIndex", currentIndex + 1);
////			PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
////			PlayerPrefs.Save();
////		}
////	}
////	public void LoadNextLevel()
////	{
////		int currentIndex = SceneManager.GetActiveScene().buildIndex;
////		int nextLevelIndex = currentIndex + 1;

////		// Check if the next level is unlocked
////		if (PlayerPrefs.GetInt("ReachedIndex", 0) >= nextLevelIndex)
////		{
////			SceneManager.LoadScene(nextLevelIndex);
////		}
////		else
////		{
////			Debug.LogWarning("Next level is not unlocked yet.");
////		}
////	}
////}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement; // Needed for scene management

//public class GameManager : MonoBehaviour
//{
//	public static GameManager instance; // Singleton instance
//	private int enemiesDestroyed = 0; // Count of destroyed enemies
//	public int totalEnemies = 3; // Total number of enemies to be destroyed to win
//	public Transform crystalTransform; // Reference to the crystal transform
//	public GameObject winPanel; // Reference to the win panel

//	void Awake()
//	{
//		// Ensure there's only one instance of GameManager
//		if (instance == null)
//		{
//			instance = this;
//			DontDestroyOnLoad(gameObject); // Optional: Keep the GameManager across scenes
//		}
//		else
//		{
//			Destroy(gameObject);
//		}
//	}

//	public void EnemyDestroyed()
//	{
//		enemiesDestroyed++;

//		Debug.Log("Enemies destroyed: " + enemiesDestroyed);

//		if (enemiesDestroyed >= totalEnemies)
//		{
//			EndGame();
//		}
//	}

//	void EndGame()
//	{
//		Debug.Log("You win, all enemies destroyed!");

//		if (winPanel != null)
//		{
//			winPanel.SetActive(true);
//		}

//		// Pause the game
//		Time.timeScale = 0f;
//		void UnlockNewLevel()
//		{
//			if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("reached index"))
//			{
//				PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
//				PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("Unlockedlevel", 1) + 1);
//				PlayerPrefs.Save();
//			}
//		}
//	}

//	// Method to restart the game
//	public void RestartGame()
//	{
//		Time.timeScale = 1f; // Resume game time
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
//	}

//	// Method to go to the main menu
//	public void GoToMainMenu()
//	{
//		Time.timeScale = 1f; // Resume game time
//		SceneManager.LoadScene(0); // Main menu scene index
//	}

//	public void UnlockNewLevel()
//	{
//		int currentIndex = SceneManager.GetActiveScene().buildIndex;
//		int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);

//		if (currentIndex >= reachedIndex)
//		{
//			PlayerPrefs.SetInt("ReachedIndex", currentIndex + 1);
//			PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
//			PlayerPrefs.Save();
//		}
//	}

//	public void LoadNextLevel()
//	{
//		int currentIndex = SceneManager.GetActiveScene().buildIndex;
//		int nextLevelIndex = currentIndex + 1;

//		// Check if the next level is unlocked
//		if (PlayerPrefs.GetInt("ReachedIndex", 0) >= nextLevelIndex)
//		{
//			// Resume game time before loading the next level
//			Time.timeScale = 1f;
//			SceneManager.LoadScene(nextLevelIndex);
//		}
//		else
//		{
//			Debug.LogWarning("Next level is not unlocked yet.");
//		}
//	}


//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance; // Singleton instance
	private int enemiesDestroyed = 0; // Count of destroyed enemies
	public int totalEnemies = 3; // Total number of enemies to be destroyed to win
	public Transform crystalTransform; // Reference to the crystal transform
	public GameObject winPanel; // Reference to the win panel

	void Awake()
	{
		// Ensure there's only one instance of GameManager
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject); // Optional: Keep the GameManager across scenes
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void EnemyDestroyed()
	{
		enemiesDestroyed++;
		Debug.Log("Enemies destroyed: " + enemiesDestroyed);

		if (enemiesDestroyed >= totalEnemies)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		Debug.Log("You win, all enemies destroyed!");

		if (winPanel != null)
		{
			winPanel.SetActive(true);
		}

		// Pause the game
		Time.timeScale = 0f;

		// Unlock the next level
		UnlockNewLevel();
	}

	// Method to restart the game
	public void RestartGame()
	{
		Time.timeScale = 1f; // Resume game time
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
	}

	// Method to go to the main menu
	public void GoToMainMenu()
	{
		Time.timeScale = 1f; // Resume game time
		SceneManager.LoadScene(1); // Replace 0 with your main menu scene index if different
	}

	// Method to unlock the next level
	public void UnlockNewLevel()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);

		if (currentIndex >= reachedIndex)
		{
			PlayerPrefs.SetInt("ReachedIndex", currentIndex + 1);
			PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
			PlayerPrefs.Save();
		}
	}

	// Method to load the next level
	public void LoadNextLevel()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		int nextLevelIndex = currentIndex + 1;

		// Check if the next level is unlocked
		if (PlayerPrefs.GetInt("ReachedIndex", 0) >= nextLevelIndex)
		{
			// Resume game time before loading the next level
			Time.timeScale = 1f;
			SceneManager.LoadScene(nextLevelIndex);
		}
		else
		{
			Debug.LogWarning("Next level is not unlocked yet.");
		}
	}
}

