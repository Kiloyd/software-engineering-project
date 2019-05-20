using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_control : MonoBehaviour
{
    #region Property

    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject Pause;
    [SerializeField]
    private GameObject Result;

    #endregion


    #region Public Function

    public void HUD_active()
    {
        HUD.SetActive(true);
        Pause.SetActive(false);
        Result.SetActive(false);
    }

    public void Pause_active()
    {
        HUD.SetActive(false);
        Pause.SetActive(true);
        Result.SetActive(false);
    }

    public void Result_active()
    {
        HUD.SetActive(false);
        Pause.SetActive(false);
        Result.SetActive(true);
    }

    public void totitle_button_click()
    {
        SceneManager.LoadScene(0);
    }

    public void setting_button_click()
    {

    }

    public void resume_button_click()
    {
        HUD_active();
    }

    public void retry_button_click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextlevel_button_click()
    {

    }

    #endregion

}
