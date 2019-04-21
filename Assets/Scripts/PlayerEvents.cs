using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    #region Property

    /*
    [SerializeField]
    private GameManager gm;
    */

    #endregion

    #region Unity

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over !");
            //gm.loseEvent();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);
            Debug.Log("picked");
            //gm.pickedpoint();
        }
    }

    #endregion
      
}
