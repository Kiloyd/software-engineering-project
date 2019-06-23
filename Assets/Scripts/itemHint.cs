using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemHint : MonoBehaviour
{
    #region Property

    [SerializeField]
    private LootTable itemTable;
    [SerializeField]
    private PlayerInventory inventory;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TextMeshProUGUI text;

    #endregion

    #region Unity

    private void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        itemImage.sprite = itemTable.lootableItems[inventory.getSelectIndex()].getSprite();
        text.text = inventory.getSelectItemAmount().ToString();
    }

    #endregion
}
