using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]   int hitPoints=10; 
    [SerializeField] ParticleSystem []hitExp;
    public void TakeDamage(Vector3 hitPoint){
        //TODO transform on the particle sys where is the hit point
        hitPoints-=1;
        Debug.Log($"Enemy hit, health remain:{hitPoints}");
        ParticleSystem curr_ps=hitExp[ Random.Range(0,hitExp.Length-1)];
        curr_ps.transform.position=hitPoint;
        curr_ps.Play();
       
        if(hitPoints<=0){
            Destroy(this.gameObject);
        }
    }

}
