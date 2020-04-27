using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;

        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if (c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                break;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ui.position = target.position;
        ui.forward = -cam.forward;
    }
}
