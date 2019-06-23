using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    [SerializeField]
    private int enemyId;    // 1:Blinky, 2:Pinky, 3:Inky, 4:Clyde

    [SerializeField]
    private NavMeshAgent agent;

    private Vector3 lastPos;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        lastPos =  GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        switch(enemyId) {
            case 1:
                BlinkyAlgo();
                break;

            case 2:
                PinkyAlgo();
                break;

            case 3:
                InkyAlgo();
                break;

            case 4:
                ClydeAlgo();
                break;

            default:
                break;
        }
    }

    private void BlinkyAlgo() {
        Vector3 pos =  GameObject.FindGameObjectWithTag("Player").transform.position;
        agent.SetDestination(pos);
    }

    private void PinkyAlgo() {
        Vector3 pos =  GameObject.FindGameObjectWithTag("Player").transform.position;

        if(pos == lastPos) {
            agent.SetDestination(pos);
        }
        else {
            agent.SetDestination(pos + 2 * calcDirection(pos, lastPos));
        }

        lastPos = pos;
    }

    private void InkyAlgo() {
        Vector3 pos =  GameObject.FindGameObjectWithTag("Player").transform.position;

        if(pos == lastPos) {
            agent.SetDestination(pos);
        }
        else {
            agent.SetDestination(pos + (-2) * calcDirection(pos, lastPos));
        }

        lastPos = pos;
    }

    private void ClydeAlgo() {
        Vector3 pos =  GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 tempPos = this.transform.position;

        if(Vector3.Distance(pos, tempPos) >= 4) {
            agent.SetDestination(pos);
        }
        else {
            agent.SetDestination(new Vector3(0, 1, 0));
        }
    }

    private Vector3 calcDirection(Vector3 curPos, Vector3 lastPos) {
        Vector3 diff = curPos - lastPos;

        if(Mathf.Abs(diff.x) >= Mathf.Abs(diff.z)) {
            if(diff.x >= 0) {
                return Vector3.right;
            }
            else {
                return Vector3.left;
            }
        }
        else {
            if(diff.z >= 0) {
                return Vector3.forward;
            }
            else {
                return Vector3.back;
            }
        }
    }
}
