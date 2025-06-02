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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in hitColliders)
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            if (!health) continue;
            health.TakeDamage(3);
            break;
        }
    }
}
