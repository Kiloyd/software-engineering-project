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
    [SerializeField]
    private CameraController player_camControl;
    [SerializeField]
    private PlayerMovement player_control;
    [SerializeField]
    private Fire_Weapon fire;

    #endregion

    #region Unity

    private void OnEnable()
    {
        player_camControl = FindObjectOfType<CameraController>();
        player_control = FindObjectOfType<PlayerMovement>();
        fire = FindObjectOfType<Fire_Weapon>();

        HUD_active();
    }

    #endregion

    #region Public Function

    public void HUD_active()
    {
        Debug.Log("HUD menu");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        HUD.SetActive(true);
        Pause.SetActive(false);
        Result.SetActive(false);
        player_camControl.enabled = true;
        fire.enabled = true;

        Time.timeScale = 1;
    }

    public void Pause_active()
    {
        Debug.Log("Pause menu");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        HUD.SetActive(false);
        Pause.SetActive(true);
        Result.SetActive(false);
        player_camControl.enabled = false;
        fire.enabled = false;

        Time.timeScale = 0;
    }

    public void Result_active()
    {
        Debug.Log("Result menu");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        HUD.SetActive(false);
        Pause.SetActive(false);
        Result.SetActive(true);
        player_camControl.enabled = false;
        player_control.enabled = false;
        fire.enabled = false;

        Time.timeScale = 0;
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
