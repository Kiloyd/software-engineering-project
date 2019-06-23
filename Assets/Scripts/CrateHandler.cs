using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [SerializeField]
    private float dropVelocity;
    [SerializeField]
    private LootTable lootTable;

    private bool isLanded;

    // Start is called before the first frame update
    void Start()
    {
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
                transform.localPosition = new Vector3(tempPos.x / 2, transform.localScale.y / 2, tempPos.z / 2);
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
        tempObject.transform.localPosition = new Vector3(tempPos.x / 2, 1, tempPos.z / 2);

        itemsObject.transform.localScale = new Vector3(1, 1, 1);

        Destroy(this.gameObject);
    }
}
