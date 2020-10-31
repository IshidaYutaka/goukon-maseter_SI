using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization

    CsPy cs;
    string pyCodePath = @"C:\Users\kikuc\Desktop\test.py";

    void Start () {
        Debug.Log("test");
        cs = GetComponent<CsPy>();
        cs.Python(pyCodePath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
