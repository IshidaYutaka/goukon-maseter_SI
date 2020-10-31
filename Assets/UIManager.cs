using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public VoiceDetectManager voiceDetectManager;
    public Sprite[] pages;
    public Image page;
    public Sprite resultPage;
    public GameObject timelineGO;
    public GameObject resultsGO;
    private int currentIndex = 0;
    // Use this for initialization
    void Start()
    {
        page.sprite = pages[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < pages.Length - 1)
            {
                currentIndex++;
                page.sprite = pages[currentIndex];
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 0;
                timelineGO.SetActive(true);
            }
        }
    }




    public void ShowResultCallBack()
    {
        page.sprite = resultPage;
        GetComponent<CanvasGroup>().alpha = 1;
        resultsGO.SetActive(true);
        var results = voiceDetectManager.sumScore;
        resultsGO.GetComponent<Text>().text = results.ToString();
    }
}
