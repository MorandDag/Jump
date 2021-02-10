using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Vector3 newPos;

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        if(target.position.y > transform.position.y)
        {
            newPos = new Vector3(0f, target.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
