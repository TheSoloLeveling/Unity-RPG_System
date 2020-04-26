using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    

    private Camera cam;
   

    public Interactable focus;

   
    PlayerMotor motor;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

       
    }

    
    void Update()
    {
       
        if (EventSystem.current.IsPointerOverGameObject())  // accessing the curent event system if its hovering over UI
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                motor.movePlayer(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

    }

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != null)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }

            focus = newFocus;
            
            motor.FollowTarget(newFocus);
        }

        focus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        
        motor.StopFollowTarget();
    }
}
