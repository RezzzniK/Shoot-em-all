using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour{
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs starterAssets;
    Animator animator;
    Weapon currentWeapon;
    bool firarateBlocked=false;
    const string KICK_BACK_STRING="KickBack";                         
    void Awake(){
        starterAssets=GetComponentInParent<StarterAssetsInputs>();
        animator=GetComponent<Animator>();
    }
    void Start(){
        currentWeapon=GetComponentInChildren<Weapon>();
    }
    void Update(){
        if (starterAssets.shoot && !firarateBlocked){
            firarateBlocked=true;
            currentWeapon.Shoot(weaponSO);
            animator.Play(KICK_BACK_STRING, -1, 0f);
            if(!weaponSO.automaticWeapon){
                 starterAssets.ShootInput(false);
            }
            StartCoroutine(FireRate()); 
        }
    }

    IEnumerator FireRate(){
        yield return new WaitForSeconds(weaponSO.FireRate);
        firarateBlocked=false;
    }
}
