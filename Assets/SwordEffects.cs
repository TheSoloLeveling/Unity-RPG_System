using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticleSpell = null;
    [SerializeField] ParticleSystem collectParticleCollision = null;

    public Transform target;
    #region Singleton

    public static SwordEffects instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        collectParticleSpell.Stop();
       

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
        collectParticleSpell.Play();
        collectParticleSpell.gameObject.SetActive(true);
    }

    public void DisableAll()
    {
        collectParticleSpell.Stop();
        collectParticleSpell.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ParticleSystem cloneEffect = Instantiate(collectParticleCollision, target);

        }
    }
}
