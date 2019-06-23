using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationHandler : MonoBehaviour
{
    [SerializeField]
    private float crateInitialHeight;

    [SerializeField]
    private GameObject cratePrefab;

    private GameObject levelObject; 

    // Start is called before the first frame update
    void Start()
    {
        levelObject = GameObject.Find("Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract() {
        Debug.Log("Station interacted");

        GameObject cratesObject = GameObject.Find("Crates");

        GameObject tempObject = Instantiate(cratePrefab);
        tempObject.transform.parent = cratesObject.transform;

        Vector3 tempPos = transform.position;
        tempObject.transform.localPosition = new Vector3(tempPos.x / 2, crateInitialHeight, tempPos.z / 2);

        cratesObject.transform.localScale = new Vector3(1, 1, 1);

        Destroy(this.gameObject);
    }
}
