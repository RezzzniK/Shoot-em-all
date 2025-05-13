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
        HandleZoom() ;
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


    public void SwitchWeapon(WeaponSO weaponPickUp){

        if(currentWeapon){
            Destroy(currentWeapon.gameObject);
        }
        weaponSO=weaponPickUp;//swaping weapons
        currentWeapon=Instantiate(weaponPickUp.weaponPrefab,transform).GetComponent<Weapon>();
       
    }

    public void HandleZoom(){
        if(!weaponSO.zoom)return;
        if(starterAssets.zoom){
            Debug.Log("zoom in");
        }else{
            Debug.Log("not zoom");
        }
    }
}
