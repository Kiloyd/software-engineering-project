using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    #region Property

    [SerializeField][Header("Score to Victory")]
    private int victoryScore;
    [SerializeField][Header("Each Score of Pellet")]
    private int pelletScore;

    private int nowScore;

    #endregion

    #region Unity

    private void Awake()
    {
        resetScore();
    }

    private void Update()
    {
        if (nowScore >= victoryScore)
            gameWin();
    }

    #endregion

    #region Public Method

    public void pickedPoint()
    {
        nowScore += pelletScore;
        // play sound effect
    }

    public void gameLose()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
        // call the result menu
    }

    public void gameWin()
    {
        Time.timeScale = 0;
        Debug.Log("Game Win");
        // call the result menu
    }

    public void resetScore()
    {
        nowScore = 0;
    }

    #endregion
}
