using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "speed boost", menuName = "Item/Speed Up", order = 2)]
public class SpeedUp : Item
{
    #region Property

    [SerializeField]
    private float speedUpFactor = 1.5f;
    [SerializeField]
    private float duration = 3.0f;

    #endregion

    #region Override function

    public override void OnUse()
    {
        FindObjectOfType<PlayerMovement>().SpeedUp(speedUpFactor, duration);
    }

    #endregion
}
