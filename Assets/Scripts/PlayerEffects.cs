using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{

    [SerializeField] ParticleSystem collectParticleRestart = null;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (  Time.timeSinceLevelLoad == 0)
        {
            ParticleSystem particleClone = Instantiate(collectParticleRestart, transform);
           
        }

    }



}
