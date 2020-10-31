using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Renci.SshNet;
using UnityEngine.SceneManagement;

public class SshConect : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool connect;

    private void Start()
    {
        connect = true;
    }
    void Update()
    {
        if (connect) {
            ResultData.result = "";
            string strResult = null;
            bool result_connect = ClsSsh.Connect("localhost", "yutaka", "yutaka0414", ref strResult);
            Debug.Log("ssh-connect:"+ result_connect);
            if (!result_connect)
            {
                Debug.Log(strResult);
            }
            connect = false;
            StartCoroutine("NextScene");
        }
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SI4_result");
    }

}

