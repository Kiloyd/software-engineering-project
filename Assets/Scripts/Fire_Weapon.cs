using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Weapon : MonoBehaviour
{
    #region Property

    [SerializeField]
    private weapon_type weapon;
    [SerializeField]
    private bool isSlowGun;

    private damage_gun damageGun;
    private slow_gun slowGun;

    #endregion

    #region Unity

    private void OnEnable()
    {
        damageGun = GetComponent<damage_gun>();
        slowGun = GetComponent<slow_gun>();
        isSlowGun = true;
    }

    private void Update()
    {
        weapon.fire_ray();
    }

    #endregion

    #region Public function

    public void change_weapon()
    {
        isSlowGun = !isSlowGun;
        if (isSlowGun)
            weapon = slowGun;
        else
            weapon = damageGun;
    }

    #endregion
}
