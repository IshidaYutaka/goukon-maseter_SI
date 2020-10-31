using UnityEngine;
using System.Collections;

public class movie : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    public GameObject obj3;

    void Start()
    {
        obj.SetActive(true);
        obj2.SetActive(false);
        obj2.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            obj.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);

        }




    }

}