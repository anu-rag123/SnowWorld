using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_script : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int i,j=0;
	public Text[] topics;
	private AudioSource drum;
	public Light my_light;
	private Color[] lightcolors = { new Color (1,0,0), new Color (0,1,0), new Color (0,0,1)};
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
		i = 0;
		drum = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		float movehorizontal=Input.GetAxis("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		rb.AddForce (movehorizontal* speed,0.0f,movevertical * speed);
		//my_light.color = new Color (0,1,0);

	}
	void changeColor()
	{
		my_light.color = lightcolors [j];
		j += 1;
		Invoke("changeColor",0.5f);
		if (j == 3)
			j = 0;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Monster")) {
			other.gameObject.SetActive (false);
			if(i!=0)
			topics [i - 1].gameObject.SetActive (false);
			topics [i].gameObject.SetActive (true);
			i+=1;
			if (i == 1)
				drum.Play ();
			else if (i == 7) {
				topics [i - 1].gameObject.SetActive (false);
				topics [i].gameObject.SetActive (true);
				changeColor ();
			}
		
				
		}
	}



}
