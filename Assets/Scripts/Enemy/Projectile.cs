using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem exp;
  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(exp,transform.position,Quaternion.identity);
            Debug.Log("Player");
            other.GetComponentInParent<PlayerHealth>().TakeDamage(2);

            Destroy(this.gameObject);
        }
        else if (other.tag == "Enemy")
        {
            Instantiate(exp,transform.position,Quaternion.identity);
            Debug.Log("Friendly fire");
            if (other)
            {
                other.GetComponentInChildren<EnemyHealth>()?.Friendlfire(20);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag != "Turret")
        {
            Instantiate(exp,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
