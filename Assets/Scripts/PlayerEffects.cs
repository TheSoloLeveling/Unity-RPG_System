using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;
    

    private void Start()
    {
        collectParticle.Stop();
        collectParticle.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collect();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            DisableAll();
        }
    }

    public void Collect()
    {
        collectParticle.Play();
        collectParticle.gameObject.SetActive(true);
    }

    public void DisableAll()
    {
        collectParticle.Stop();
        collectParticle.gameObject.SetActive(false);
    }

    
}
