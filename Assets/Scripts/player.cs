using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
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
        if(collision.gameObject.tag == "enemy")
        {
            Debug.Log("Game Over !");
            //gm.loseEvent();
        }

    }

    #endregion
      
}
