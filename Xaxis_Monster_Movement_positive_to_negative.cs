using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xaxis_Monster_Movement_positive_to_negative : MonoBehaviour {

	public GameObject[] Monsters_positive_to_negative;
	private int[] flags={0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private Vector3[] add_sub={new Vector3(0.05f,0.0f,0.0f),new Vector3(0.05f,0.0f,0.0f),new Vector3(0.5f,0.0f,0.0f),new Vector3(0.5f,0.0f,0.0f),new Vector3(0.0f,0.0f,0.5f),new Vector3(0.0f,0.0f,0.4f),new Vector3(0.0f,0.0f,0.5f),new Vector3(0.5f,0.2f,0.0f),new Vector3(0.5f,0.2f,0.0f),new Vector3(0.3f,0.1f,0.0f),new Vector3(0.5f,0.0f,0.0f),new Vector3(0.0f,0.0f,0.5f),new Vector3(0.0f,0.0f,0.5f),new Vector3(0.0f,0.0f,1.0f)};
	private Vector3[] positives={new Vector3(1.28f,-2.98f,22.39f),new Vector3(5.5f,-13.8f,86.47f),new Vector3(11.5f,-13.8f,156.7f),new Vector3(9.8f,-13.8f,202.2f),new Vector3(50.0f,-13.8f,408.8f),new Vector3(147.1f,-13.8f,408.3998f),new Vector3(226.1f,15.5f,408.1f),new Vector3(350.1f,55.10003f,405.4f),new Vector3(350.1f,55.10003f,388.03f),new Vector3(418.899f,82.19987f,395.2f),new Vector3(9.8f,-13.8f,220.3f),new Vector3(2.63f,-13.8f,291.33f),new Vector3(-4.56f,-13.8f,291.33f),new Vector3(2.63f,-13.8f,408.4f)};
	private Vector3[] negatives={new Vector3(-2.32f,-2.98f,22.39f),new Vector3(-5.5f,-13.8f,86.47f),new Vector3(-12.5f,-13.8f,156.7f),new Vector3(2.3f,-13.8f,202.2f),new Vector3(50.0f,-13.8f,385.8f),new Vector3(147.1f,-13.8f,388.8001f),new Vector3(226.1f,15.5f,385.6f),new Vector3(323.1f,44.29998f,405.4f),new Vector3(323.1f,44.29998f,388.03f),new Vector3(393.7f,73.8f,395.2f),new Vector3(-11.2f,-13.8f,220.3f),new Vector3(2.63f,-13.8f,258.33f),new Vector3(-4.56f,-13.8f,258.33f),new Vector3(2.63f,-13.8f,309.4f)};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 14; i++)
		{
			if (flags [i] == 0)
				Monsters_positive_to_negative [i].transform.position += add_sub [i];
			if (Monsters_positive_to_negative [i].transform.position == positives [i])
				flags [i] = 1;
			if (flags [i] == 1)
				Monsters_positive_to_negative [i].transform.position -= add_sub [i];
			if (Monsters_positive_to_negative [i].transform.position == negatives [i])
				flags [i] = 0;
				
		}
	}
}


