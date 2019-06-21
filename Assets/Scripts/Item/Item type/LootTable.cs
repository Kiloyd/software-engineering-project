using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "item table", menuName = "Item table", order = 2)]
public class LootTable : ScriptableObject
{
    #region Property

    [SerializeField]
    public List<Item> lootableItems;
    public bool AutoRefreshOnEmpty = false;
    private int totalWeight;

    #endregion

    #region Unity

	private void OnEnable()
    {
        UnityEngine.Random.seed = System.Guid.NewGuid().GetHashCode();
        totalWeight = CalcWeight(lootableItems);
    }
    #endregion

    #region Public function

    private int CalcWeight(List<Item> lootableItems)
    {
        int sum = 0;

        foreach (Item i in lootableItems)
        {
            sum += i.getWeight();
        }

        return sum;
    }

    public GameObject getItem()
    {
        int sum = 0;
        int index = UnityEngine.Random.Range(0, totalWeight - 1);

        Item tempItem = null;

        foreach (Item i in lootableItems)
        {
            sum += i.getWeight();

            if (sum > index)
            {
                tempItem = i;
                break;
            }
        }

        return tempItem.getPrefab();
    }

    #endregion
}
