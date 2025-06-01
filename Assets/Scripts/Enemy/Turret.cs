using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;//we will use camera root transform otherwise because of the pivot of the player pos, turret will shoot to the players feet
    [SerializeField] Transform projetileSpawnPointPos;
    [Range(1,10)]
    [SerializeField] float turretFR = 10f;
    [SerializeField] GameObject turretProjectile;
    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(fireRoutine());
    }
    void Update()
    {
        if (playerTargetPoint != null)
        {
            turretHead.transform.LookAt(playerTargetPoint);
        }

    }

    IEnumerator fireRoutine()
    {
        while (player)
        {

            yield return new WaitForSeconds(turretFR);
            Instantiate(turretProjectile, projetileSpawnPointPos.position, turretHead.rotation);
        }
    }                                        
}
