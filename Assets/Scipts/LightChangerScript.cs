
using UnityEngine;

public class LightChangerScript : MonoBehaviour {

	public Light My_Light;
	private Color[] Light_Colors ={new Color (1,0,0),new Color (0,1,0), new Color (0,0,1)};
	private int i = 0;
	private AudioSource BeginningSceneSound;

	private void ChangeLightColor()
	{
		My_Light.color = Light_Colors [i];
		i += 1;
		if (i == 3)
			i = 0;
		Invoke("ChangeLightColor",0.5f);
	}

	void Start()
	{
		Invoke("ChangeLightColor",2);
		BeginningSceneSound = GetComponent <AudioSource> ();
		BeginningSceneSound.Play ();
	}


}
