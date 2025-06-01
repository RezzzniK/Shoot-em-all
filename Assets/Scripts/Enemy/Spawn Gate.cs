using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robot;
    [SerializeField] GameObject player;
    [Range(1,10)]
    [SerializeField] float spawnTime=5f;
    bool spawnRobot;

    void Awake()
    {
        spawnRobot=true;
    }
    void Update()
    {
        if (spawnRobot)
        {
            spawnRobot=false;
            StartCoroutine(delayFroSpawn() );
           
        }
    }

    void SpawnRobot()
    {
        if (player != null) Instantiate(robot, this.transform.position, Quaternion.identity);
        spawnRobot = true;
    }
    IEnumerator delayFroSpawn() {
        
        yield return new WaitForSeconds(spawnTime);
        SpawnRobot();
    }
}
