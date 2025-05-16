using UnityEngine;

public class AmmoPickUp : PickUpBase
{
    [SerializeField] int ammoFillAmount=150;
    protected override void PickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmoAmount(ammoFillAmount);
    }

  
}
