using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    #region Property

    [SerializeField]
    private float interactDistance;
    [SerializeField]
    private float interactHoldTime;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            eventRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(eventRay, out eventHit, interactDistance))
            {
                if (eventHit.collider.gameObject.name == "Station(Clone)" || eventHit.collider.gameObject.name == "Crate(Clone)")
                {
                    isKeyHeld = false;

                    startTime = Time.time;
                    timer = startTime;

                    eventObject = eventHit.collider.gameObject;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && isKeyHeld == false)
        {
            timer += Time.deltaTime;

            if (timer > (startTime + interactHoldTime))
            {
                isKeyHeld = true;

                if(eventObject.name == "Station(Clone)") {
                    eventObject.GetComponent<StationHandler>().OnInteract();
                }
                else if(eventObject.name == "Crate(Clone)") {
                    eventObject.GetComponent<CrateHandler>().OnInteract();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isKeyHeld = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
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