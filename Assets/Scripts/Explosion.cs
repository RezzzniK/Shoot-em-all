using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    void Start()
    {
        Explode();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);//this will draw our radius sphere
    }
    void Explode()
    {
        //do damage to player
    }
}
