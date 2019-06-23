using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : ScriptableObject
{
    #region Property

    [SerializeField]
    protected GameObject prefab;
    [SerializeField]
    protected int weight;
    [SerializeField]
    protected Collider interact_area;
    [SerializeField]
    protected Sprite ItemImage;

    #endregion

    #region Unity

    private void OnEnable()
    {
        interact_area = prefab.GetComponent<Collider>();
        interact_area.isTrigger = true;
    }

    #endregion

    #region Interface function

    public virtual void OnUse()
    {
        // provide player use after they have it in PlayerInventory.
    }

    #endregion

    #region Public function

    public int getWeight()
    {
        return weight;
    }

    public GameObject getPrefab()
    {
        return prefab;
    }

    public string getName()
    {
        return prefab.name;
    }

    public Sprite getSprite()
    {
        return ItemImage;
    }

    #endregion
}
