using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    #region Property

    [SerializeField]
    private float stationDistance;

    [SerializeField]
    private float stationHoldTime;

    private GameHandler gm;

    private Ray eventRay;
    private RaycastHit eventHit;
    private GameObject eventObject;

    private bool isKeyHeld;
    private float startTime;
    private float timer;

    #endregion

    #region Unity

    private void OnEnable()
    {
        gm = FindObjectOfType<GameHandler>();
    }

    private void Start()
    {
        isKeyHeld = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            eventRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(eventRay, out eventHit, stationDistance)) {
                if(eventHit.collider.gameObject.name == "Station(Clone)") {
                    isKeyHeld = false;

                    startTime = Time.time;
                    timer = startTime;

                    eventObject = eventHit.collider.gameObject;
                }
            }
        }

        if(Input.GetKey(KeyCode.E) && isKeyHeld == false) {
            timer += Time.deltaTime;

            if(timer > (startTime + stationHoldTime)) {
                isKeyHeld = true;

                eventObject.GetComponent<StationHandler>().OnInteract();
            }
        }

        if(Input.GetKeyUp(KeyCode.E)) {
            isKeyHeld = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);  // may need edit.
            Debug.Log("picked");
            gm.pickedPoint();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over !");
            gm.gameLose();
        }
    }

    #endregion
      
}
