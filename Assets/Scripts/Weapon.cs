using System.Collections;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFxp;
    Light light;//TODO muzzel heat when shooting for machine gun
 
    void Awake()
    {
        light = GetComponentInChildren<Light>();
    }
    private void FixedUpdate()
    {
        // if (light && light.intensity>0)
        // {
        //     light.intensity-=5;


        // }
        // // else if (light && muzzleFxp.isPlaying)
        // // {
        // //     light.intensity+=5;
        // // }
    }
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFxp.Play();

        // if (light)
        // {

        //     light.intensity =50;
        // }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.collider.gameObject);
            var enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
            Instantiate(weaponSO.hitEffect, hit.point, Quaternion.identity);
            if (enemy != null)
            {
                enemy.TakeDamage(hit, weaponSO.Damage);
            }
        }
    }

    // IEnumerator turnofLight(){
    //     yield return new WaitForSeconds(1f);
    //     light.enabled=false;
    // }

}
