using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Property

    [SerializeField]
    private float countdownTime;
    [SerializeField]
    private bool trigger;

    private float setTime;


    #endregion

    #region Public method

    public void CountDown()
    {
        setTime += Time.deltaTime;

        if (setTime >= countdownTime)
            trigger = true;
    }

    public void resetTime()
    {
        setTime = 0;
        trigger = false;
    }

    public bool getTrigger()
    {
        return trigger;
    }

    #endregion

}
