using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    #region Property

    [SerializeField][Header("Movement speed")]
    private float speed = 1f;

    private Rigidbody rb;
    private float sum;

    #endregion

    #region Unity 

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        sum = 0.001f;
    }

    // Use this for initialization
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        sum = Mathf.Sqrt(Input.GetAxis("Horizontal") * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * Input.GetAxis("Vertical")) + 0.001f;
        //Debug.Log(sum.ToString());

        // maybe use velocity = max(0.5, calculate speed)
        rb.velocity = Input.GetAxis("Horizontal") / sum * speed * transform.right + Input.GetAxis("Vertical") / sum * speed * transform.forward;
    }

    #endregion
}
