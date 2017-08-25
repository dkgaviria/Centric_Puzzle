using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Condition : MonoBehaviour {
    public int correct { get; private set; }

    // Use this for initialization
    void Start()
    {

    }
    private void Win_Condition.WinGame()
    {
        if (correct == 0)
            {
               MonoBehaviour.print("Good Work");
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
