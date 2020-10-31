using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void onClick() {
        SceneManager.LoadScene("SI0_start");
    }
}
