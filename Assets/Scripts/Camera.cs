using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime;
    Vector3 refPos;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref refPos, smoothTime);
    }
}
