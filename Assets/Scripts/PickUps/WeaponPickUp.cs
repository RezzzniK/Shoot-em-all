 using UnityEngine;
public class WeaponPickUp : PickUpBase
{
    [SerializeField] WeaponSO weaponSO;

    protected override void PickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
}
