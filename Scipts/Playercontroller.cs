using UnityEngine;
using UnityEngine.UI;


public class Playercontroller : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource collection,removal_of_wall,sliding_sound,monster_sound,capsule_sound;
	public Text gain_text,health_percentage,lives;
	public Slider health;
	public GameObject removingwall,friendwall,slider,monster,removingwall1,camera1,camera2,capsule,slider2,_fill;
	private Vector3 offset;
	private int counter,no_of_lives;
	private int flag,flag_for_camera,flag_for_camera1;
	private float speed;
	#if UNITY_ANDROID
	private bool forward, back, left, right;
	#endif
	public Button forward_Button, Back_Button, Left_Button, Right_Button;



	void Start()
	{
		rb = GetComponent<Rigidbody>();
		collection = GetComponent<AudioSource> ();
		removal_of_wall = friendwall.GetComponent<AudioSource> ();
		sliding_sound = slider.GetComponent<AudioSource> ();
		monster_sound = monster.GetComponent<AudioSource> ();
		capsule_sound = capsule.GetComponent<AudioSource> ();
		counter = 0;
		flag = 1;
		flag_for_camera = 0;
		flag_for_camera1=0;
		no_of_lives = 2;
		speed = 10;
		offset = camera1.transform.position - transform.position;
		gain_text.text ="Gain : " + counter.ToString() ;
		health.value = 100;
		health_percentage.text = "Health : " + (health.value).ToString()  + " %" ;
		lives.text = "Lives : 2";
		#if UNITY_ANDROID
		forward = back = left = right = false;
		#endif
	}


	void respawn()
	{
		_fill.SetActive (true);
		health.value = 100;
		health_percentage.text = "Health : " + (health.value).ToString () + " %";
	}
	#if UNITY_ANDROID
	public void MoveBall_Forward_Start()
	{
		forward = true;
	}

	public void MoveBall_Forward_Stop()
	{
		forward = false;
	}

	public void MoveBall_Back_Start()
	{
		back = true;
	}

	public void MoveBall_Back_Stop()
	{
		back = false;
	}

	public void MoveBall_Left_Start()
	{
		left = true;
	}

	public void MoveBall_Left_Stop()
	{
		left = false;
	}

	public void MoveBall_Right_Start()
	{
		right = true;
	}

	public void MoveBall_Right_Stop()
	{
		right = false;
	}
	#endif


	void FixedUpdate()   // This function is used for physics in our game.Our ball will move when a force will be applied to it,this is a physics hence our code will for 
	{                   //  moving the ball will be inside this FixedUpdate()  function.
		#if UNITY_STANDALONE 
		float movehorizontal=Input.GetAxis("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		forward_Button.gameObject.SetActive(false);
		Back_Button.gameObject.SetActive(false);
		Left_Button.gameObject.SetActive(false);
		Right_Button.gameObject.SetActive(false);
		#endif
		#if UNITY_ANDROID

		if ( forward == true && flag_for_camera == 0)
			rb.AddForce(Vector3.forward*speed);

		else if ( forward == true && flag_for_camera == 1)
			rb.AddForce(Vector3.right*speed);

		if ( back == true && flag_for_camera == 0)
			rb.AddForce(Vector3.back*speed);

		else if ( back == true && flag_for_camera == 1)
			rb.AddForce(Vector3.left*speed);

		if ( left == true && flag_for_camera == 0)
			rb.AddForce(Vector3.left*speed);

		else if ( left == true && flag_for_camera == 1)
			rb.AddForce(Vector3.forward*speed);
		
		if ( right == true && flag_for_camera == 0)
			rb.AddForce(Vector3.right*speed);

		else if ( right == true && flag_for_camera == 1)
			rb.AddForce(Vector3.back*speed);


		#endif

		if (flag_for_camera == 0) {
			camera1.transform.position = transform.position + offset;

			#if UNITY_STANDALONE 
			rb.AddForce (movehorizontal * camera1.transform.right* speed);
			rb.AddForce (movevertical * camera1.transform.forward * speed);
			#endif

		}		

		else if (flag_for_camera == 1 ) {
			camera2.transform.position = transform.position + offset;

			#if UNITY_STANDALONE 
			rb.AddForce (movehorizontal * camera2.transform.right * speed);
			rb.AddForce (movevertical * camera2.transform.forward * speed);
			#endif
		} 

		if (transform.position.y < -13.6f)
		{
			health.value = 0;
			_fill.SetActive (false);
			health_percentage.text = "Health : " + (health.value).ToString () + " %";
			no_of_lives -= 1;
			lives.text = "Lives : " + no_of_lives.ToString ();
			if (no_of_lives > 0)
				respawn ();
			if (flag == 0 && flag_for_camera == 0 && flag_for_camera1 == 0) 
				transform.position = new Vector3 (0.5306f, -12.35f, 127.35f);
			else if ( flag == 1 && flag_for_camera == 0 && flag_for_camera1 == 0)
				transform.position = new Vector3 (-0.1052946f, -0.1833777f, 14.77342f);
			else if (flag_for_camera == 1 && flag_for_camera1 == 0)
				transform.position = new Vector3 (79.18937f,-12.1f,396.1868f);
			else if (flag_for_camera1 == 1)
				transform.position = new Vector3 (316.638f,45.17633f,395.5874f);
		}
	}


		void OnTriggerEnter(Collider other)
	{

		 if (other.gameObject.CompareTag ("Pick up"))
		{
			other.gameObject.SetActive (false);
			collection.Play ();
			counter += 1;
			gain_text.text = "Gain : " + counter.ToString();
			health.value += 1;
			health_percentage.text = "Health : " + (health.value).ToString () + " %";
		}

		if (counter == 8)
		{
			removal_of_wall.Play ();
			removingwall.SetActive (false);
		}

		if (counter == 16) {
			removal_of_wall.Play ();
			removingwall1.SetActive (false);
		} 

		else if (other.gameObject.CompareTag ("capsule")) 
		{
			other.gameObject.SetActive (false);
			capsule_sound.Play ();
			health.value = 100;
			health_percentage.text = "Health : " + (health.value).ToString()  + " %" ;
		} 

		else if (other.gameObject.CompareTag ("key")) 
		{
			other.gameObject.SetActive (false);
			removal_of_wall.Play ();
			slider2.SetActive (true);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Slider")) {
			sliding_sound.Play ();

		} 

		else if (other.gameObject.CompareTag ("Ground4") && flag_for_camera == 0)
		{
			offset = new Vector3 (-9.06f, 0.01999855f, 395.85f) -  new Vector3 (19.25f, -12.1f, 396.89f);
			camera2.transform.position = transform.position + offset;
			camera2.SetActive (true);
			camera1.SetActive (false);
			flag_for_camera = 1;
		}

		else if (other.gameObject.CompareTag ("Ground4") && flag_for_camera1 == 1)
		{
			
			flag_for_camera1 = 0;
		}

		else if (other.gameObject.CompareTag ("Road2") && flag_for_camera == 1) 
		{
		
			offset = new Vector3 (-1.19331f, 0.01999855f, 364.7852f) -  new Vector3 (-1.194557f, -12.1f, 393.8849f);
			camera1.transform.position = transform.position + offset;
			camera2.SetActive (false);
			camera1.SetActive (true);
			flag_for_camera = 0;
		} 

		else if (other.gameObject.CompareTag ("Monster"))
		{
			monster_sound.Play ();
			health.value -= 5;
			health_percentage.text = "Health : " + (health.value).ToString () + " %";
			if (health.value == 0) 
			{
				no_of_lives -= 1;
				_fill.SetActive (false);
				lives.text = "Lives : " + no_of_lives.ToString ();
				if (no_of_lives > 0)
					respawn ();

			}


		} 

		else if (other.gameObject.CompareTag ("Road2") && flag == 1)
		{
			if (counter < 16) {
				transform.position = new Vector3 (-0.1052946f, -0.1833777f, 14.77342f);
			} 
			else {
				removingwall1.SetActive (true);
				transform.localScale += new Vector3 (1.0f, 1.0f, 1.0f);
				flag = 0;
				speed = 15;
			}
		}
		else if (other.gameObject.CompareTag ("Final_Road_1")) 
		{
			flag_for_camera1 = 1;
		} 
	}
}




