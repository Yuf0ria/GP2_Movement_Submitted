using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
