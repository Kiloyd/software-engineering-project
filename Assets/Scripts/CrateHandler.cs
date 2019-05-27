using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [SerializeField]
    private float dropVelocity;

    private LootTable lootTable;

    private bool isLanded;

    // Start is called before the first frame update
    void Start()
    {
        lootTable = this.GetComponent<LootTable>();
        isLanded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLanded == false) {
            transform.Translate(Vector3.down * Time.deltaTime * dropVelocity);

            Vector3 tempPos = transform.position;
            if((tempPos.y - transform.localScale.y / 2) < 0) {
                isLanded = true;
                transform.localPosition = new Vector3(tempPos.x, transform.localScale.y / 2, tempPos.z);
            }
        }
    }

    public void OnInteract() {
        Debug.Log("Crate interacted");

        GameObject itemPrefab = lootTable.getItem();

        GameObject itemsObject = GameObject.Find("Items");

        GameObject tempObject = Instantiate(itemPrefab);
        tempObject.transform.parent = itemsObject.transform;

        Vector3 tempPos = transform.position;
        tempObject.transform.localPosition = new Vector3(tempPos.x, 3, tempPos.z);

        itemsObject.transform.localScale = new Vector3(1, 1, 1);

        Destroy(this.gameObject);
    }
}
