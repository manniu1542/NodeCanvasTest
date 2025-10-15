using UnityEngine;
using NavMeshAgent = UnityEngine.AI.NavMeshAgent;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{

    private NavMeshAgent navAgent;

    void Awake() {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {

        if ( Input.GetMouseButtonDown(0) ) {
            RaycastHit hit;
            if ( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) ) {
                navAgent.SetDestination(hit.point);
            }
        }
    }
}
