using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zommSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float yawSpeed = 100f;
    public float pitch = 3.2f;
    private float currentZomm = 10f;

    private float yawInput = 0f;
   

    void Start()
    {
        
    }

    private void Update()
    {
        currentZomm -= Input.GetAxis("Mouse ScrollWheel") * zommSpeed;
        currentZomm = Mathf.Clamp(currentZomm, minZoom, maxZoom);

        yawInput += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - (offset * currentZomm);
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yawInput);
    }
}
