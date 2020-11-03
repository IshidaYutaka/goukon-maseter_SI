using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void onClick() {
        Debug.Log("クリック");
        SceneManager.LoadScene(0);
    }
}
