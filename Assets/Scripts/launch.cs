using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class launch : MonoBehaviour {

	public Vector3 init_speed = new Vector3(-1.5f, 0f, 0f);
	private float fallTime;
	private float shotTime;
	private Rigidbody rbGO;
	private GameObject arrow;
	private bool started;
	public ForceInput force;
	public Vector3 init_pos;
	private bool triggered;
	private bool reset;
	protected bool fire_button = false;
	protected JoyButton joybutton;
	protected Joystick joystick;
	private GameObject Wood;
	private GameObject Platform;
	private GameObject Can;
	private GameObject Target;
	private GameObject Target2;

	// Use this for initialization
	void Start() {
		// Initialse The launch
		fallTime = 0.0f;
		shotTime = 0.0f;
		started = false;
		triggered = false;

		reset = false;
		rbGO = GetComponent<Rigidbody>();
		arrow = GameObject.Find("arrow");
		init_pos = transform.localPosition;
		rbGO.useGravity = false;

		joybutton = FindObjectOfType<JoyButton>();

	}
	public void QuitApp() { 
		// Exit the Game
		Application.Quit();
}
	public void AllReset() {


		// Obtain the Index of the active Level 
		int level = SceneManager.GetActiveScene().buildIndex;

		Debug.Log(level);
		Target = GameObject.Find("MainTarget");
		float x = Target.transform.position.x;
		float y = Target.transform.position.y;
		float z = Target.transform.position.z;

		Target2 = GameObject.Find("SecondTarget");
		float x2 = Target.transform.position.x;
		float y2 = Target.transform.position.y;
		float z2 = Target.transform.position.z;

		// Restore the Wood Platform for Level 2
		if (level == 3)
        {
			Wood = GameObject.Find("Wood");
			Rigidbody rb = Wood.GetComponent<Rigidbody>();
			Wood.transform.position = new Vector3(x2 + -0.087f, y2 + 0.075f, z2 + 0f);

			Wood.transform.rotation = Quaternion.identity;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;

			Platform = GameObject.Find("Wood_Platform");
			Rigidbody rba = Platform.GetComponent<Rigidbody>();
			Platform.transform.position = new Vector3(x2 + -0.087f, y2 + 0.152f, z2 + 0f);

			Platform.transform.rotation = Quaternion.identity;
			rba.velocity = Vector3.zero;
			rba.angularVelocity = Vector3.zero;

		}

		// Restore the Cans
		for (int i = 1; i <= 6; i++) {
			 Can = GameObject.Find ("Can" + i.ToString ());
			Rigidbody rbb = Can.GetComponent<Rigidbody>();

			
			// Restore the Configuration for Level 3
			if (level == 4)
			{
				if (i == 1)
					Can.transform.position = new Vector3(x+ -0.1f, y+ 0.03f, z+ 0f);
				if (i == 2)
					Can.transform.position = new Vector3(x+ 0f, y+ 0.03f, z+ 0f);
				if (i == 3)
					Can.transform.position = new Vector3(x+ 0.1f, y+ 0.03f, z+ 0f);
				if (i == 4)
					Can.transform.position = new Vector3(x+ -0.025f, y+ 0.072f, z+ 0f);
				if (i == 5)
					Can.transform.position = new Vector3(x+ 0.025f, y+ 0.072f, z+ 0f);
				if (i == 6)
					Can.transform.position = new Vector3(x+ 0f, y+ 0.115f, z+ 0f);
			}

			// Restore the Configuration for Level 2
			if (level == 3)
			{
				if (i == 6)
					Can.transform.position = new Vector3(x2 + -0.14f,y2 + 0.18f, z2 + 0f);
				if (i == 2)
					Can.transform.position = new Vector3(x + 0f, y + 0.03f, z + 0f);
				if (i == 3)
					Can.transform.position = new Vector3(x + 0.05f, y + 0.03f, z + 0f);
				if (i == 5)
					Can.transform.position = new Vector3(x2 + -0.053f, y2 + 0.18f,z2 + 0f);
				if (i == 4)
					Can.transform.position = new Vector3(x + 0.02f, y + 0.072f,z + 0f);
				if (i == 1)
					Can.transform.position = new Vector3(x + 0.025f, y + 0.115f, z + 0f);
			}

			// Restore the Configuration for Level 1
			if (level == 2)
			{
				if (i == 1)
					Can.transform.position = new Vector3(x+ -0.05f, y+ 0.03f, z+ 0f);
				if (i == 2)
					Can.transform.position = new Vector3(x+ 0f, y+ 0.03f, z+ 0f);
				if (i == 3)
					Can.transform.position = new Vector3(x+ 0.05f, y+ 0.03f, z+ 0f);
				if (i == 4)
					Can.transform.position = new Vector3(x+ -0.025f, y+ 0.072f, z+ 0f);
				if (i == 5)
					Can.transform.position = new Vector3(x+ 0.025f, y+ 0.072f,z+  0f);
				if (i == 6)
					Can.transform.position = new Vector3(x+ 0f, y+ 0.115f, z+ 0f);
			}

			Can.transform.rotation = Quaternion.identity;    
			rbb.velocity = Vector3.zero;
			rbb.angularVelocity = Vector3.zero;
		}
		force.score = 0;
	}

	
	void Update () {

		// Launch the ball
		started = Input.GetMouseButtonDown (1);
        if (joybutton)
        {
            if (!fire_button && joybutton.pressed)
            {
                fire_button = true;
                started = true;
            }

            // Stop Launch
            if (fire_button && !joybutton.pressed)
                fire_button = false;
        }

        reset = Input.GetMouseButtonDown (2);

		// Check for ball speed, if above threshold, start timer
		if (Vector3.Magnitude(rbGO.velocity) > 0.01 && triggered == false) {
			
			triggered = true;
		}
		
		
		if (reset) {
			AllReset ();
		}
		// Play when the Timer is On
		if (fallTime > 0.0f)
		{
			if (started)
			{
				shotTime = 0.0f;
				triggered = true;
				rbGO.WakeUp();
				rbGO.useGravity = true;
				Vector3 Xaxis = new Vector3(0,1,0);
				Vector3 RotatedX = arrow.transform.rotation * Xaxis;
				RotatedX *= -force.ballspeed;
				rbGO.AddForce(RotatedX, ForceMode.Impulse);
				started = false;
			}
		}
		else
		{
			rbGO.Sleep();
		}

		fallTime += Time.deltaTime;

		if (triggered) {
			shotTime += Time.deltaTime;
			if (shotTime > 5.0f) {
				transform.localPosition = init_pos;
				rbGO.Sleep ();
				rbGO.useGravity = false;
				triggered = false;
				shotTime = 0.0f;
			}
		}
	}
}
