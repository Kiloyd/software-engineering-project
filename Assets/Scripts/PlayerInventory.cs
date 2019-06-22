using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Property

    [SerializeField]
    private LootTable itemTable;
    [SerializeField]
    private List<int> inventory;
     [SerializeField]
     private int nowSelectIndex;

    #endregion

    #region Unity 

    private void Start()
    {
        // initialize
        for (int i = 0; i < itemTable.lootableItems.Count; i++)
            inventory.Add(0);

        nowSelectIndex = 0;
    }

    private void Update()
    {
        select_and_use();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Get Item: " + other.name);
            // register to inventory
            register_item(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    #endregion

    #region Private function

    private void register_item(string itemName)
    {
        for(int i = 0;  i < itemTable.lootableItems.Count; i++)
        {
            if(itemName == (itemTable.lootableItems[i].getName() + "(Clone)"))
            {
                inventory[i] += 1;
                Debug.Log("add item to inventory");
                break;
            }
        }
    }

    private void select_and_use()
    {
          if(Input.GetAxis("Mouse ScrollWheel") != 0)
          {
               if(Input.GetAxis("Mouse ScrollWheel") > 0)
               {
                    if (nowSelectIndex - 1 >= 0)
                         nowSelectIndex --;
               }
               else
               {
                    if (nowSelectIndex + 1 < itemTable.lootableItems.Count)
                         nowSelectIndex ++;
               }
          }

        if (Input.GetKey(KeyCode.F))
        {
            if(inventory[nowSelectIndex] > 0)
            {
                inventory[nowSelectIndex]--;
                itemTable.lootableItems[nowSelectIndex].OnUse();
            }
        }

    }

    #endregion
}
