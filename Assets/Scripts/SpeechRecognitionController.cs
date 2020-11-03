using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechRecognitionController : MonoBehaviour
{

    // Use this for initialization

    private VoiceDetectManager voiceManager;
   
    void Start()
    {
    }

    void OnEnable()
    {
        voiceManager.StartSpeechRecognition();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
