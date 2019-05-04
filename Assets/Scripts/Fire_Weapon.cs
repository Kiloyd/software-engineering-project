using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Weapon : MonoBehaviour
{
    #region Property

    [SerializeField]
    private Camera cam;

    private Ray fire_ray;
    private RaycastHit fire_hit;

    #endregion

    #region Unity

    private void OnEnable()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire_ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0));

            if (Physics.Raycast(fire_ray, out fire_hit, float.MaxValue))
            {
                Debug.DrawRay(fire_ray.origin, fire_ray.direction * 10, Color.red);
                Debug.Log(fire_hit.point.ToString() + " " + fire_hit.collider.gameObject.name);
            }
        }
    }

    #endregion
}
