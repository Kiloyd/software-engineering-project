using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_type : MonoBehaviour
{
    #region Property

    [SerializeField]
    protected Camera player_cam;

    protected Ray ray;
    protected RaycastHit hit;

    #endregion

    #region Unity

    private void OnEnable()
    {
        player_cam = FindObjectOfType<Camera>();
    }

    #endregion

    #region Interface function

    public virtual void fire_ray()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // play sound

            ray = player_cam.ScreenPointToRay(new Vector3(player_cam.pixelWidth / 2, player_cam.pixelHeight / 2, 0));
            if(Physics.Raycast(ray, out hit, float.MaxValue))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                Debug.Log(hit.point.ToString() + " " + hit.collider.gameObject.name);

                hit_effect();
            }
        }
    }

    public virtual void hit_effect()
    {

    }

    #endregion
}
