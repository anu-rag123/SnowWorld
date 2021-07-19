using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject Gamename_Panel;
	private AudioSource CompanyNameSound;

	private void TaketoScene1()
	{
		SceneManager.LoadSceneAsync ("FirstScene");
	}
	private void TakeToGameName()
	{
		Gamename_Panel.gameObject.SetActive (true);
		gameObject.SetActive (false);
		Invoke ("TaketoScene1",3);
	}

	void Start()
	{
		CompanyNameSound = GetComponent <AudioSource> ();
		CompanyNameSound.Play ();
		Invoke ("TakeToGameName",3);
	}


}
