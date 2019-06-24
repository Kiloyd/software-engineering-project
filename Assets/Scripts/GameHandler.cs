using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    #region Property

    [SerializeField][Header("Score to Victory")]
    private int victoryScore;
    [SerializeField][Header("Each Score of Pellet")]
    private int pelletScore;
    [SerializeField]
    private UI_control UIcontroller;

    private int nowScore;

    private GameObject points;

    #endregion

    #region Unity

    private void Start()
    {
        points = GameObject.Find("Pellets");
        UIcontroller = FindObjectOfType<UI_control>();
        Debug.Log("All Points: " + points.transform.childCount.ToString());
    }

    private void Awake()
    {
        resetScore();
    }

    private void Update()
    {
        //if (nowScore >= victoryScore)
            //gameWin();
    }

    #endregion

    #region Public Method

    public void pickedPoint()
    {
        nowScore += pelletScore;
        // play sound effect

        Debug.Log("Points to Victory: " + (victoryScore - nowScore).ToString());
        if(nowScore >= victoryScore) {
            gameWin();
        }
    }

    public void gameLose()
    {
        Debug.Log("Game Over");
        // call the result menu
        UIcontroller.Result_active();
    }

    public void gameWin()
    {
        Debug.Log("Game Win");
        // call the result menu
        UIcontroller.Result_active();
    }

    public void resetScore()
    {
        nowScore = 0;
    }

    #endregion
}
