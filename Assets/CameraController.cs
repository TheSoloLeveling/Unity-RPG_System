using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 3.2f;
    private float currentZomm = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - (offset * currentZomm);
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
