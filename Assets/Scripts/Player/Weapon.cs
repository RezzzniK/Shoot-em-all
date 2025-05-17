using System.Collections;
using Cinemachine;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFxp;
    [SerializeField] LayerMask interactionLayers;
    Light light;//TODO muzzel heat when shooting for machine gun
  
    CinemachineImpulseSource recoil;
    void Awake()
    {
        light = GetComponentInChildren<Light>();
        recoil=GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFxp.Play();
        recoil.GenerateImpulse();
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity,interactionLayers,QueryTriggerInteraction.Ignore))
        {
            // Debug.Log(hit.collider.gameObject);
            var enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
            Instantiate(weaponSO.hitEffect, hit.point, Quaternion.identity);
            if (enemy != null)
            {
                enemy.TakeDamage(hit, weaponSO.Damage);
            }
        }
    }


}
