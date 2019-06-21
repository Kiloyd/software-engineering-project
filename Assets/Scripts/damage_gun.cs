using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_gun : weapon_type
{
    #region Override Function

    public override void fire_ray()
    {
        base.fire_ray();
    }

    public override void hit_effect()
    {
        if (hit.collider.gameObject.tag == "Enemy")
        {
            Debug.Log("damage hit effect");
            Destroy(hit.collider.gameObject);
        }
    }

    #endregion
}
