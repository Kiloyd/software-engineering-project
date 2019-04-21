using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    #region Property

    [SerializeField]
    private gameManager gm;

    #endregion

    #region Unity

    private void OnEnable()
    {
        gm = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);  // may need edit.
            Debug.Log("picked");
            gm.pickedPoint();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over !");
            gm.gameLose();
        }
    }

    #endregion
      
}
