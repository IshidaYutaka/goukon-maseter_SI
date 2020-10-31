using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector movieTimeline;
    public PlayableDirector mainTrainingTimeline;

    public enum GameState
    {
        introduction,
        preTraining,
        mainTraining,
        results
    }

    public GameState gameState = GameState.introduction;
    bool isPreTrainingEnd = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isPreTrainingEnd == true)
        {
            mainTrainingTimeline.Play();
            movieTimeline.Resume();
            StartCoroutine(DelayFunction());

        }
    }


    void OnEnable()
    {
        if (isPreTrainingEnd == false)
        {
            movieTimeline.Pause();
            isPreTrainingEnd = true;
            gameState = GameState.mainTraining;
        }
    }

    IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds(1.0f);
        movieTimeline.Pause();
    }

    public void ResultsCallBack()
    {
        mainTrainingTimeline.Pause();
    }
}
