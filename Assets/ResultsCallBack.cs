using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsCallBack : MonoBehaviour {

    public UIManager uiManager;
    public TimelineController timelineController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        uiManager.ShowResultCallBack();
        timelineController.ResultsCallBack();
    }
}
