using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for the Image component

public class SoundManager : MonoBehaviour
{
	[SerializeField] Image on;
	[SerializeField] Image off;
	private bool muted = false;

	// Start is called before the first frame update
	void Start()
	{
		if (!PlayerPrefs.HasKey("muted"))
		{
			PlayerPrefs.SetInt("muted", 0);
		}

		Load();
		UpdateButtonIcon();
		AudioListener.pause = muted;
	}

	public void OnButtonPress()
	{
		muted = !muted;
		AudioListener.pause = muted;

		Save();
		UpdateButtonIcon();
	}

	private void UpdateButtonIcon()
	{
		if (muted)
		{
			on.enabled = false;
			off.enabled = true;
		}
		else
		{
			on.enabled = true;
			off.enabled = false;
		}
	}

	private void Load()
	{
		muted = PlayerPrefs.GetInt("muted") == 1;
	}

	private void Save()
	{
		PlayerPrefs.SetInt("muted", muted ? 1 : 0);
	}
}
