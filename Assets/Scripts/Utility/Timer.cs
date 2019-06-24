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
    [SerializeField]
    private float setTime;

    #endregion

    #region Public method

    public void CountDown()
    {
        setTime += Time.deltaTime;

        if (setTime >= countdownTime)
        {
            trigger = true;
            setTime = countdownTime;
        }

    }

    public void setCountdownTime(float value)
    {
        countdownTime = value;
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

    public float getTime()
    {
        return setTime;
    }

    public float getCountdownTime()
    {
        return countdownTime;
    }

    #endregion

}
