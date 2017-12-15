using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterBehaviour : MonoBehaviour
{
    float Timer = 0.0f;
    public GameObject Sea = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sea.transform.Translate(Vector3.left * 1.5f * Time.smoothDeltaTime);
        //Timer += Time.deltaTime;
        //if (Timer >= 1.0f)
        //{
        //    Timer = 0.0f;
        //    //Sea.transform.position = transform.position + (diff.normalized * 3.0f * Time.deltaTime);
        //    //Sea.transform 
        //}
    }
}
