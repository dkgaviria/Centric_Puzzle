using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour {
    public GameObject circle;
    public bool correct;
    public float mouseY;
    public float threshold=0;
	// Use this for initialization
	void Start () {
        circle.transform.Rotate(new Vector3(0, 22.5f * Random.Range(2,25), 0));

    }
    private void OnMouseDown()
    {
        if(this.gameObject.tag=="Circle")
        {
            
            threshold = Input.mousePosition.y;
        }
        
    }

    private void OnMouseDrag()
    {
        mouseY = Input.mousePosition.y;
       
        if (threshold - mouseY >= 30)
        {
            threshold = mouseY;
            circle.transform.Rotate(new Vector3(0,22.5f,0));
            

        }

        else if(threshold - mouseY <= -30)
        {
            threshold = mouseY;
            circle.transform.Rotate(new Vector3(0, -22.5f, 0));
           

        }
        
    }
    private void OnMouseUp()
    {

        if (Mathf.RoundToInt( circle.transform.eulerAngles.y)==0)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
