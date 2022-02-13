using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceInput : MonoBehaviour {

    public float ballspeed ;
	public GUIStyle style;
	public int score = 0;
	private GameObject Can;
	private bool vert_test;
	private Quaternion localQ;
	private float fallTime = 0.0f;
    float angle = 0.0f;
    Vector3 axis = Vector3.zero;
    public float slider_v;
    public Slider speed_slider;

	

    private bool[] scored = {false,false,false,false,false,false,false};

		// Display the Score
		void OnGUI () {
			float x = Screen.width / 2f;
			float y = 30f;
			float width = 300f;
			float height = 20f;
			string text_speed = "Ball Speed: " + ballspeed.ToString ();
			string text_score = "Score = " + score.ToString ();

			GUI.Label(new Rect(x-(width/2f), y, width, height), text_speed, style);
			GUI.Label(new Rect(x-(width/2f), y+100f, width, height), text_score, style);
			
			if (score == 60) {
			string game_over = "NICELY DONE, BRAVO !!";
			GUI.Label(new Rect(x-(width/1f), y+400f, width, height), game_over, style);
			
		}
		}

    public void slide_change (float value)
    {
            slider_v = value;
    }

	void Start() {

        if (speed_slider)
            speed_slider.onValueChanged.AddListener(slide_change);

        for (int i = 1; i <= 6; i++) {
			scored [i] = false;
		}
		score = 0;
		fallTime = 3.0f;
        
    }
		void Update() {

		// Wait for the Ball to return
		if (fallTime > 5.0f) {

            ballspeed = slider_v;


			if (ballspeed < 0)
				ballspeed = 0;
			// Add 10 to score if Can has moved
			for (int i = 1; i <= 6; i++) {
	
				Can = GameObject.Find ("Can" + i.ToString ());
                localQ = Can.transform.rotation;
                localQ.ToAngleAxis(out angle, out axis);

				float magRot = Mathf.Abs (localQ.eulerAngles.x) + Mathf.Abs (localQ.eulerAngles.z);
				if (Can != null && i == 1)
                {
     
                }
                vert_test = true;
				if (magRot > 10 && magRot < 350)
					vert_test = false;
				if (magRot < -10 && magRot > -350)
					vert_test = false;
				if (vert_test == false && scored [i] == false) {
					//Debug.Log ("Can " + i + " has scored");
					//Debug.Log ("localQ=" + magRot);
					score += 10;
					scored [i] = true;
				}
			}
		}
		fallTime += Time.deltaTime;

	}
}
