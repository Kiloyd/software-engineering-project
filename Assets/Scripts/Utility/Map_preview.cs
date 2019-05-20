using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TMPro
{
    public class Map_preview : MonoBehaviour
    {
        #region Property

        [SerializeField]
        private TMP_Dropdown level_select;
        [SerializeField]
        private Image display;
        [SerializeField]
        private Sprite[] preview_image;

        #endregion

        #region Unity

        private void OnEnable()
        {
            level_select = FindObjectOfType<TMP_Dropdown>();
            display = GetComponent<Image>();
        }

        #endregion

        #region Public Function

        public void dropdown_value_change()
        {
            display.sprite = preview_image[level_select.value];
        }

        public void game_start()
        {
            SceneManager.LoadScene(level_select.value + 1);
        }

        #endregion

    }
}
