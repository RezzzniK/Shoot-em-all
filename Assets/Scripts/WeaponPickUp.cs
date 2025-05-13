using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    ActiveWeapon activeWeapon;
    const string PLAYER="Player";
    void Awake()
    {
        activeWeapon=FindFirstObjectByType<ActiveWeapon>();
    }
        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==PLAYER){

            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(this.gameObject);
        }
    }

}
