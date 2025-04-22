using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;//refernce for our NavMeshAgent Component
   // [SerializeField] Transform target;//destenation to move to
    void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=FindFirstObjectByType<FirstPersonController>();
        //agent.SetDestination(target.position);
    }
    void Update(){
       // agent.SetDestination(target.position);
       agent.SetDestination(player.transform.position);
    }
    
}
