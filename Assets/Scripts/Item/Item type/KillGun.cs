using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "kill gun", menuName = "Item/Kill Gun", order = 1)]
public class KillGun : Item
{
    #region Override function

    public override void OnUse()
    {
        FindObjectOfType<Fire_Weapon>().change_weapon();
    }

    #endregion
}
