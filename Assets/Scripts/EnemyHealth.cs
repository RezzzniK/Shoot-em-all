
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]   int hitPoints=10; 
    [SerializeField] ParticleSystem []hitExp;
    public void TakeDamage(RaycastHit hit){
        //TODO transform on the particle sys where is the hit point
        hitPoints-=1;
        
        ParticleSystem curr_ps=hitExp[ Random.Range(0,hitExp.Length-1)];
        //ParticleSystem effect = Instantiate(curr_ps, hit.point, Quaternion.identity);
        curr_ps.transform.position = hit.point;
        curr_ps.transform.rotation = Quaternion.identity;
        curr_ps.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
        
        curr_ps.Play();
     
        if(hitPoints<=0){
            Destroy(this.gameObject);
        }
    }

}
