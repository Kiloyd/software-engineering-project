﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Property

    [SerializeField][Header("Movement speed")]
    private float speed = 1f;
    [SerializeField][Header("Stop speed threshold")]
    private float stop_speed = 0.1f;

    private Rigidbody rb;
    private float sum;
    private float horizontal_speed;
    private float vertical_speed;

    #endregion

    #region Unity 

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        sum = 0.001f;
        horizontal_speed = 0f;
        vertical_speed = 0f;
    }

    // Use this for initialization
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        sum = Mathf.Max(Mathf.Sqrt(Input.GetAxis("Horizontal") * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * Input.GetAxis("Vertical")), 0.1f) ;
        //Debug.Log(sum.ToString());

        horizontal_speed = (Mathf.Abs(Input.GetAxis("Horizontal") * speed) < stop_speed) ? 0f : Input.GetAxis("Horizontal") * speed;
        vertical_speed = (Mathf.Abs(Input.GetAxis("Vertical") * speed) < stop_speed) ? 0f : Input.GetAxis("Vertical") * speed;

        rb.velocity = horizontal_speed / sum * transform.right + vertical_speed / sum * transform.forward;
    }

    #endregion
}
