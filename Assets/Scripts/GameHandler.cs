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

        int remainPoints = points.transform.childCount;
        Debug.Log("Remaining Points: " + remainPoints);
        if(remainPoints <= 0) {
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
