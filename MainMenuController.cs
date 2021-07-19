using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour {

	public GameObject PlaySettingsAboutQuit, InsideSettings;
	public Button BackButton;
	public AudioMixer MainMixer, GameMixer;
	public Dropdown GraphicsDropdown;

	void Start()
	{
		GraphicsDropdown.ClearOptions ();
		List<string> options = new List<string> ();
		for (int i = 0; i < QualitySettings.names.Length; i++) 
		{	
			string option = QualitySettings.names [i];
			options.Add (option);
		}

		GraphicsDropdown.AddOptions (options);
		GraphicsDropdown.value = QualitySettings.GetQualityLevel ();
		GraphicsDropdown.RefreshShownValue ();
	}
	public void OnClickToSettings()
	{
		PlaySettingsAboutQuit.gameObject.SetActive (false);
		InsideSettings.gameObject.SetActive (true);
		BackButton.gameObject.SetActive (true);
	}

	public void OnClickToSoundSlider(float volume)
	{
		MainMixer.SetFloat ("Volume",volume);
	}

	public void OnClickToGameSoundSlider(float volume)
	{
		GameMixer.SetFloat ("GameVolume",volume);
	}

	public void OnClickToBack()
	{
		InsideSettings.gameObject.SetActive (false);
		PlaySettingsAboutQuit.gameObject.SetActive (true);
		BackButton.gameObject.SetActive (false);
	}

	public void OnClickToPlay()
	{
		SceneManager.LoadScene ("Minigame");
	}

	public void OnClickToGraphicsDropDown(int value)
	{
		QualitySettings.SetQualityLevel (value);
	}


}
