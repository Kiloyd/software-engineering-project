using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour
{
    [SerializeField]
    private float dropVelocity;

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
                transform.localPosition = new Vector3(tempPos.x, transform.localScale.y / 2, tempPos.z);
            }
        }
    }
}
