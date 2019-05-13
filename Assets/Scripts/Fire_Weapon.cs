using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Weapon : MonoBehaviour
{
    #region Property

    [SerializeField]
    private weapon_type weapon;

    #endregion

    #region Unity

    private void Update()
    {
        weapon.fire_ray();
    }

    #endregion
}
