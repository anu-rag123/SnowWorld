using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssetsTransfer : MonoBehaviour {

	private float x;
	private float AlphaColorComponent;
	private static float increement = 0.1f;
	private AudioSource AssetsSound,BackgroundSound;
	public GameObject Snowman, SnowmanWife, Monster2, Monster1, LightForSound, TransitionPanel;
	public Text AssetsText, WifeText, WhereText, WelcomeText;
	private static int flag = 0;
	private static int flag1 = 0;
	private static int flag2 = 0, counter = 0, counter1 = 0, counter2 = 0;
	private Image TransitionImage;


	public void TakeToMainMenu()
	{		
		SceneManager.LoadSceneAsync("MainMenu");
	}


	private void FlyTheMonster()
	{
		Monster2.transform.position -= new Vector3 (0.0f,0.0f,0.002f);
	}

	private void PositioningMonsterOnYaxis()
	{
		Monster2.transform.position += new Vector3 (0.0f,0.0125f,0.0f);

	}
	private void PositioningMonsterOnXaxis()
	{
		Monster2.transform.position -= new Vector3 (0.0125f,0.0f,0.0f);
	}


	private void RotatingMonster()
	{
		Monster2.transform.Rotate (new Vector3(0,-0.1f,0));
	}


	private void TransferAssets()
	{
		x += increement;
		transform.position = new Vector3 (x, transform.position.y,transform.position.z);

	
		if (x == -6.86f) 
		{
			AssetsSound.Play ();
			AssetsText.gameObject.SetActive (true);
		}

	}

	private void TransferWife()
	{
		SnowmanWife.transform.position += new Vector3 (0.01f, 0.0f, 0.0f);
	}

	void Start()
	{
		AssetsSound = Snowman.GetComponent <AudioSource> ();
		BackgroundSound = LightForSound.GetComponent <AudioSource> ();
		TransitionImage = TransitionPanel.GetComponent <Image> ();
		x = transform.position.x;
		AlphaColorComponent = TransitionImage.color.a;
		Invoke ("TransferAssets", 2);
	}

	// Update is called once per frame
	void Update () 
	{
		if (x < 5.21f)
			TransferAssets ();

		else if (SnowmanWife.transform.position.x < 5.21f) {
			if (flag == 0) {
				AssetsText.gameObject.SetActive (false);
				SnowmanWife.gameObject.SetActive (true);
				WifeText.gameObject.SetActive (true);
				flag = 1;
			}
			TransferWife ();
		} 

		else if (flag == 1) {
			if (flag2 == 0) {
				SnowmanWife.gameObject.SetActive (false);
				WifeText.gameObject.SetActive (false);
				Monster1.gameObject.SetActive (false);
				Monster2.gameObject.SetActive (true);
				flag2 = 1;
			} 
			else if (flag2 == 1) {
				if (counter < 600) {
					counter += 1;
					counter1 += 1;
					counter2 += 1;
					RotatingMonster ();

					if (counter1 < 290)
						PositioningMonsterOnXaxis ();

					if (counter2 < 240)
						PositioningMonsterOnYaxis ();
				}

				else
				{
					flag = 0;
					WhereText.gameObject.SetActive (true);
				}

			}
		} 

		else if (flag == 0 && flag1 == 0) {
			if (Monster2.transform.position.z > -11.7)
				FlyTheMonster ();
			else {
				WhereText.gameObject.SetActive (false);
				WelcomeText.gameObject.SetActive (true);
				BackgroundSound.Pause ();
				flag1 = 1;
				TransitionPanel.gameObject.SetActive (true);
			}
		}

		else if (flag1 == 1) 
		{
			  AlphaColorComponent += 0.002f;
			if (AlphaColorComponent > 0.8) {
				flag1 = -1;
				TakeToMainMenu ();
			}
			else
			TransitionImage.color = new Color (TransitionImage.color.r,TransitionImage.color.g,TransitionImage.color.b,AlphaColorComponent);

		}


	}
}
