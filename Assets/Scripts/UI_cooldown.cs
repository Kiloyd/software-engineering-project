using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_cooldown : MonoBehaviour
{
    #region Property 

    [SerializeField]
    private Slider bar;
    [SerializeField]
    private Timer timer;

    #endregion

    #region Unity

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        bar = GetComponent<Slider>();
    }

    private void Update()
    {
        if(!timer.getTrigger())
            bar.value = bar.maxValue - timer.getTime() / timer.getCountdownTime();
    }

    #endregion

    #region Public function 
    #endregion

    #region Private function 
    #endregion
}
