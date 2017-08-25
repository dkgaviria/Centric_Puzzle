using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour {
    public GameObject[] circles;
	// private Vector3[] circleRotations;
    public bool correct;
    public float mouseY;
    public float threshold=0;

	// Use this for initialization
	void Start () {
		circles = GameObject.FindGameObjectsWithTag("Subcircle");
		// circleRotations = new Vector3[circles.Length]; 

		for (int i = 0; i < circles.Length; i++) {

			// randomly rotate, and keep track of the rotation
			Vector3 randomRotation = new Vector3 (0, 22.5f * Random.Range (2, 25), 0);
			// circleRotations[i] = randomRotation;
			circles[i].transform.Rotate(randomRotation);

			// add subcircle controller
			if (circles[i].GetComponent<SubCircle_Controller>() == null) {
				circles[i].AddComponent<SubCircle_Controller> ().parent = this;
			}
		}

    }
    public void OnSubcircleClick(GameObject subcircle)
    {
    	threshold = Input.mousePosition.y;
    }

    public void OnSubcircleDrag(GameObject subcircle)
    {
        mouseY = Input.mousePosition.y;
       
        if (threshold - mouseY >= 30)
        {
            threshold = mouseY;
            subcircle.transform.Rotate(new Vector3(0,22.5f,0));
			// circleRotations[System.Array.IndexOf (circles, subcircle)] = new Vector3(0,22.5f,0)
            

        }

        else if(threshold - mouseY <= -30)
        {
            threshold = mouseY;
            subcircle.transform.Rotate(new Vector3(0, -22.5f, 0));
        }
        
    }
	public void OnSubcircleUp(GameObject sub)
    {
		Quaternion firstRotation = circles[0].transform.rotation;
		print (firstRotation);
		for (int i = 1; i < circles.Length; i++) {
			float angle = Quaternion.Angle (firstRotation, circles[i].transform.rotation);

			if (angle > 0) {
				print (circles [i].transform.rotation);
				break;
			} else if (i == circles.Length - 1) {
				restart ();
			}
		}
    }

	private void restart () {
		for (int i = 0; i < circles.Length; i++) {

			// randomly rotate, and keep track of the rotation
			Vector3 randomRotation = new Vector3 (0, 22.5f * Random.Range (2, 25), 0);
			// circleRotations[i] = randomRotation;
			circles[i].transform.Rotate(randomRotation);

			// add subcircle controller
			if (circles[i].GetComponent<SubCircle_Controller>() == null) {
				circles[i].AddComponent<SubCircle_Controller> ().parent = this;
			}
		}
	}
    // Update is called once per frame
    void Update () {

	}
}

