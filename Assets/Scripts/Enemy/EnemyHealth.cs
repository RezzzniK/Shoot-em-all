
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem[] hitExp;
    [SerializeField] ParticleSystem robotExp;
    
    public void TakeDamage(RaycastHit hit, int damageAmount)
    {
        //TODO transform on the particle sys where is the hit point
        hitPoints -= damageAmount;

        ParticleSystem curr_ps = hitExp[Random.Range(0, hitExp.Length - 1)];
        //ParticleSystem effect = Instantiate(curr_ps, hit.point, Quaternion.identity);
        curr_ps.transform.position = hit.point;
        curr_ps.transform.rotation = Quaternion.identity;
        curr_ps.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);

        curr_ps.Play();

        if (hitPoints <= 0)
        {
            SelfDestruct();
        }

    }

    public void SelfDestruct()
    {
        Instantiate(robotExp, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
