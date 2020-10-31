using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples;
using System;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceDetectManager : MonoBehaviour
{

    //this is the duration of the detection
    public GCSpeechRecognition _speechRecognition;
    public float detectTime;
    public List<float> DetectTimeList = new List<float>();
    public float highScore;
    public float lowScore;

    //SceneManager speechRecognition;
    private bool startTimer = false;
    private float time = 0;
    [NonSerialized]
    public int sumScore = 0;

    [Serializable]
    private enum PointState
    {
        highPoint,
        lowPoint,
        noPoint
    }
    private PointState pointState;

    // Use this for initialization
    void Start()
    {
        //speechRecognition = GetComponent<SceneManager>();
        pointState = PointState.noPoint;
        _speechRecognition = GCSpeechRecognition.Instance;
        _speechRecognition.RecognitionSuccessEvent += SpeechRecognizedSuccess;

    }

    public void StartCountDown(int n)
    {
        //this function should be call after video played
        //Debug.Log(n + "Detect function start");
        StartCoroutine(DelayMethod(DetectTimeList[n], () =>
        {
            //   Debug.Log(n + "Detect function start");

            StartRecord();
        }));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int n = 0;
            while (n < DetectTimeList.Count)
            {
                StartCountDown(n);
                n++;
            }
        }

        if (startTimer)
        {
            time += Time.deltaTime;
            if (time <= 0.2f)
            {
                pointState = PointState.highPoint;
            }
            else if (time <= 0.5f)
            {
                pointState = PointState.lowPoint;
            }
            else
            {
                pointState = PointState.noPoint;
            }
        }

    }
    public void StartSpeechRecognition()
    {
        //Debug.Log("start speech recognition");
        int n = 0;
        while (n < DetectTimeList.Count)
        {
            StartCountDown(n);
            n++;
        }
    }

    void StartRecord()
    {
        //speechRecognition.StartRecordButtonOnClickHandler();
        startTimer = true;
    }

    void EndRecord()
    {
        //speechRecognition.StopRecordButtonOnClickHandler();
        startTimer = false;
        time = 0;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
        yield return new WaitForSeconds(detectTime);
        EndRecord();
    }

    void SpeechRecognizedSuccess(RecognitionResponse obj, long txt)
    {
        if (pointState == PointState.highPoint)
        {
            sumScore += 3;
        }
        else if (pointState == PointState.highPoint)
        {
            sumScore += 1;
        }
        Debug.Log("current sumScore = " + sumScore);
    }

}
