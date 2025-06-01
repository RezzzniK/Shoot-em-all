using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;//refernce for our NavMeshAgent Component
    const string PLAYER = "Player";
    EnemyHealth health;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponentInChildren<EnemyHealth>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        //agent.SetDestination(target.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER && health != null)
        {
            health.SelfDestruct();
        }
    }
    void Update()
    {
        if (player) agent.SetDestination(player.transform.position);
    }


}
