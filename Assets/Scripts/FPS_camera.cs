using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_camera : MonoBehaviour
{
    #region Property

    // the highest and lowest angle that player can adjust.
    [SerializeField][Header("the highest and lowest angle")]
    private float maximumX;
    [SerializeField]
    private float minimumX;

    // mouse sensitivity, X and Y means the axis of the screen. 
    [SerializeField][Header("Mouse sensitivity")]
    private float sensitivityX;
    [SerializeField]
    private float sensitivityY;

    // head rotate X axis, body rotate Y axis.
    [SerializeField][Header("transform that do the rotation")]
    private Transform head;
    [SerializeField]
    private Transform body;

    // rotation axis for X and Y axis. Remind that they're different to sensitivities way.
    private float rotateX;
    private float rotateY;


    #endregion

    #region Unity 

    private void OnEnable()
    {
        rotateX = 0f;
        rotateY = 0f;
    }

    private void Update()
    {
        rotateY += Input.GetAxis("Mouse X") * sensitivityX;
        rotateX -= Input.GetAxis("Mouse Y") * sensitivityY;

        // only clamp the X axis rotation, no need for Y axis.
        rotateX = Mathf.Clamp(rotateX, minimumX, maximumX);

        head.localEulerAngles = new Vector3(rotateX, 0, 0);
        body.localEulerAngles = new Vector3(0, rotateY, 0);
    }

    #endregion

}
