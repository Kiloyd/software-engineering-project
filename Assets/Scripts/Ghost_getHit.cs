using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost_getHit : MonoBehaviour
{
    #region Property

    private NavMeshAgent agent;
    private float speed_temp;
    private bool slow_trigger;

    #endregion

    #region Unity

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    #endregion

    #region Public Function

    public void slow_hit(float rate, float time)
    {
        StartCoroutine(slow(rate, time));
    }

    public void damage_hit()
    {
        Destroy(this.gameObject);
    }

    #endregion

    #region IENumerator

    IEnumerator slow(float slow_rate, float slow_time)
    {
        speed_temp = agent.speed;
        agent.speed *= slow_rate;

        slow_trigger = false;

        yield return new WaitForSeconds(slow_time);

        agent.speed = speed_temp;
        slow_trigger = true;
    }

    #endregion
}
