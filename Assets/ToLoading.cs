using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ToLoading : MonoBehaviour
{
    public VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("toloading");
        vp.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(vp.frame + "/1331");
        if ((ulong)vp.frame == vp.frameCount-3) {
            SceneManager.LoadScene("loading");
        }
        //Debug.Log(vp.frame + "/"+(vp.frameCount - (ulong)3));
    }
}
