using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xaxis_monster_movement_negative_to_positive : MonoBehaviour {

	public GameObject[] Monsters_negative_to_positive;
	private int [] flags={0,0,0,0,0};
	private Vector3[] add_sub={new Vector3(0.5f,0.0f,0.0f),new Vector3(0.5f,0.0f,0.0f),new Vector3(0.0f,0.0f,0.5f),new Vector3(0.5f,0.2f,0.0f),new Vector3(0.0f,0.0f,1.0f)};
	private Vector3[] positives={new Vector3(11.5f,-13.8f,177.3f),new Vector3(-4.3f,-13.8f,202.3f),new Vector3(242.6f,19.45f,406.5f),new Vector3(350.1f,55.10003f,396.44f),new Vector3(-4.56f,-13.8f,402.6f)};
	private Vector3[] negatives={new Vector3(-12.5f,-13.8f,177.3f),new Vector3(-11.8f,-13.8f,202.3f),new Vector3(242.6f,19.45f,384.5f),new Vector3(323.1f,44.29998f,396.44f),new Vector3(-4.56f,-13.8f,307.6f)};
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 5; i++)
		{
			if (flags [i] == 0)
				Monsters_negative_to_positive [i].transform.position -= add_sub [i];
			if (Monsters_negative_to_positive [i].transform.position == negatives [i])
				flags [i] = 1;
			if (flags [i] == 1)
				Monsters_negative_to_positive [i].transform.position += add_sub [i];
			if (Monsters_negative_to_positive [i].transform.position == positives [i])
				flags [i] = 0;

		}
	}

}
