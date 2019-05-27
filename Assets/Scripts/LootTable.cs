using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootTable : MonoBehaviour {

    # region Property
    public string Name;
    public bool AutoRefreshOnEmpty = false;

    [System.Serializable]
    public class Item : ICloneable
    {
        public string name;
        public GameObject prefab;
        public int weight;

        public object Clone() {
            return this.MemberwiseClone();
        }
    }

    [SerializeField]
    public List<Item> lootableItems;

    private int totalWeight;

    # endregion

    # region Unity

	private void Start() {
        UnityEngine.Random.seed = System.Guid.NewGuid().GetHashCode();
        totalWeight = CalcWeight(lootableItems);
    }

    private int CalcWeight(List<Item> lootableItems) {
        int sum = 0;

        foreach(Item i in lootableItems) {
            sum += i.weight;
        }

        return sum;
    }

    public GameObject getItem() {
        int sum = 0;
        int index = UnityEngine.Random.Range(0, totalWeight-1);

        Item tempItem = null;

        foreach(Item i in lootableItems) {
            sum += i.weight;

            if(sum > index) {
                tempItem = i;
                break;
            }
        }

        return tempItem.prefab;
    }

    # endregion
}
