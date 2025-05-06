using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssets;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem []traceEXP;
    [SerializeField] ParticleSystem muzzleFxp;
    const string KICK_BACK_STRING="KickBack";//string name of the state that we need to
                                             // pass to the animator

    void Awake()
    {
        starterAssets=GetComponentInParent<StarterAssetsInputs>();
      
    }
    
    void Update()
    {
        if (starterAssets.shoot){

            RaycastHit hit;//our raycast type
           
            muzzleFxp.Play();

            animator.Play(KICK_BACK_STRING,-1,0f);//if we not setting normlized 
                                                // time it will work only first time
                                                    
            traceEXP[ Random.Range(0,traceEXP.Length-1)].Play();
            starterAssets.ShootInput(false);
            if ( Physics.Raycast(Camera.main.transform.position,/*our origin,
                                                            also we not catching the camera ref
                                                            because the camera ref is built in by unity
                                                            so no need to catch it*/
                            Camera.main.transform.forward,/**our direction,
                                                        we know that our camera is poointing 
                                                        to the center of our screen
                                                        */
                            out hit,/**passing through our reference*/
                            Mathf.Infinity/**on this step we will shout a ray to infinity distance*/                        
                        ))
            {
                Debug.Log(hit.collider.gameObject);//will tell us what we hitting,
                var enemy=hit.collider.gameObject.GetComponent<EnemyHealth>();
                if (enemy != null){
                   // Debug.DrawRay(hit.point, hit.normal, Color.yellow, 1f);
                    enemy.TakeDamage(hit);
                }
            }
            
        }

    }

   
}
