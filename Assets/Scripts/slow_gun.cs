using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slow_gun : weapon_type
{
    #region Property

    [SerializeField]
    private float slow_rate = 0.5f;
    [SerializeField]
    private float slow_time = 0.5f;
    [SerializeField]
    private float force_factor = 1;
    [SerializeField]
    private float recovery_time = 1.5f;
    [SerializeField]
    private Timer countdown;

    private float speed_temp = 0f;
    private bool slow_trigger = true;

    #endregion

    #region Unity

    private void Start()
    {
        countdown = GetComponent<Timer>();
    }

    private void Update()
    {
        if(!countdown.getTrigger())
            countdown.CountDown();
    }

    #endregion

    #region Override function

    public override void fire_ray()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (countdown.getTrigger())
            {
                // play sound

                ray = player_cam.ScreenPointToRay(new Vector3(player_cam.pixelWidth / 2, player_cam.pixelHeight / 2, 0));
                if (Physics.Raycast(ray, out hit, float.MaxValue))
                {
                    Debug.DrawRay(ray.origin, ray.direction, Color.red);
                    Debug.Log(hit.point.ToString() + " " + hit.collider.gameObject.name);

                    hit_effect();
                }
                countdown.resetTime();
            }
        }
    }

    public override void hit_effect()
    {
        if (hit.collider.gameObject.tag == "Enemy" && slow_trigger == true)
        {
            Debug.Log("slow hit effect");
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
