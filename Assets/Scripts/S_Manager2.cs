using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class S_Manager2 : MonoBehaviour
{

    public VideoPlayer videoPlayer;  //アタッチした VideoPlayer をインスペクタでセットする
    public GameObject obj;

    void Start()
    {
        // 即再生されるのを防ぐ.
        //videoPlayer.playOnAwake = false;
        videoPlayer.Prepare();
    }
    // 読込完了時のコールバック.
    void OnCompletePrepare()
    {
        // 読込が完了したら再生.
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((ulong)videoPlayer.frame == (videoPlayer.frameCount - 3))
        {
            SceneManager.LoadScene(obj.name);
        }
    }
}