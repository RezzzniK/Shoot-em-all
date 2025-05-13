using UnityEngine;

[CreateAssetMenu(fileName ="WeaponSO",menuName ="Scriptable Objects/WeaponSO")]
public class WeaponSO:ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage=1;
    public float FireRate=.5f;

    public ParticleSystem hitEffect;
    public bool automaticWeapon=false;
}
 