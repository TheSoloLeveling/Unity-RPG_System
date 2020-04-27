using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    
    

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        
    }

   

    public GameObject player;
    

    public void KillPlayer()
    {
         StartCoroutine(DoDie());
         
       
    }

    IEnumerator DoDie()
    {
        PlayerAnimator.instance.DeathAnimation();
        PlayerMotor.FindObjectOfType<NavMeshAgent>().speed = 0;
        yield return new WaitForSeconds(5f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        
    }
}
