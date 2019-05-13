using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slow_gun : weapon_type
{
    #region Property

    public GameObject enemy;
    [SerializeField]
    private float slow_rate = 0.5f;
    [SerializeField]
    private float slow_time = 2f;

    private float speed_temp = 0f;
    private bool slow_trigger = true;

    #endregion


    #region Override function

    public override void fire_ray()
    {
        base.fire_ray();
    }

    public override void hit_effect()
    {
        if (hit.collider.gameObject.name == enemy.name && slow_trigger == true)
        {
            StartCoroutine(slow_enemy());
        }
    }

    #endregion

    #region IENumerator

    IEnumerator slow_enemy()
    {
        speed_temp = hit.collider.gameObject.GetComponent<NavMeshAgent>().speed;
        hit.collider.gameObject.GetComponent<NavMeshAgent>().speed *= slow_rate;

        slow_trigger = false;

        yield return new WaitForSeconds(slow_time);

        hit.collider.gameObject.GetComponent<NavMeshAgent>().speed = speed_temp;
        slow_trigger = true;
    }

    #endregion
}
