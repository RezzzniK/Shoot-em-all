using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public bool zoom = false;
    public ParticleSystem hitEffect;
    public bool automaticWeapon = false;
    public float zoomInValue = 10f;
    public float zoomOutValue = 40f;
    public float rotationAmount = 1f;
    public int magazineSize = 0;
}
