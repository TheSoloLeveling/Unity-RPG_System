using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private Animator anim;

    PlayerMotor motor;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();

    }

    
    void FixedUpdate()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                motor.movePlayer(hit.point);
                anim.speed = motor.agent.speed;
            }
        }
        
    }
}
