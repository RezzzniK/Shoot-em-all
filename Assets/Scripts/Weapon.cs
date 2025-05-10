using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFxp;
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFxp.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity))
        {
            Debug.Log(hit.collider.gameObject);
            var enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
            Instantiate(weaponSO.hitEffect, hit.point, Quaternion.identity);
            if (enemy != null){
                enemy.TakeDamage(hit, weaponSO.Damage);
            }
        }
    }

}
