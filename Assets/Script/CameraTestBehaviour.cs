using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTestBehaviour : MonoBehaviour
{
    public GameObject movecamera;
    Vector2 norm = Vector2.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            norm.x -= 1.0f;
        else if (Input.GetKeyDown(KeyCode.S))
            norm.x += 1.0f;
        else if (Input.GetKeyDown(KeyCode.Q))
            norm.x -= 10.0f;
        else if (Input.GetKeyDown(KeyCode.A))
            norm.x += 10.0f;
        else if (Input.GetKeyDown(KeyCode.E))
            norm.x -= 5.0f;
        else if (Input.GetKeyDown(KeyCode.D))
            norm.x += 5.0f;
        else
        {
            norm = Vector2.zero;
            return;
        }

        //norm.Normalize();

        Vector3 tt = movecamera.transform.position;
        tt.x += norm.x;
        movecamera.transform.position= tt;

    }
}
