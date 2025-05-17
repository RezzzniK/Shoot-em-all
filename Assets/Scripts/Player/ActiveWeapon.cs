using System.Collections;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ActiveWeapon : MonoBehaviour{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField]Image zoom;
    [SerializeField] GameObject followCamera;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Camera weaponCamera;
    WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssets;
    FirstPersonController firstPersonController;
    Animator animator;
    Weapon currentWeapon;
    CinemachineVirtualCamera camera;
    float defaultRotationSpeed=1f;
    bool firarateBlocked=false;
    int currentAmmo;
    int max_ammo=0;
    const string KICK_BACK_STRING = "KickBack";
    void Awake(){
        starterAssets = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        camera = followCamera.GetComponent<CinemachineVirtualCamera>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
    }
    void Start()
    {
        //on start we will switch our weapon to startingWeaponSO
        SwitchWeapon(startingWeaponSO);
        max_ammo=currentWeaponSO.magazineSize;
        //currentWeapon =GetComponentInChildren<Weapon>();
    }
    void Update(){
        HandleZoom() ;
        if (starterAssets.shoot && !firarateBlocked && currentAmmo>0){
            
            firarateBlocked =true;
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(KICK_BACK_STRING, -1, 0f);
            if(!currentWeaponSO.automaticWeapon){
                 starterAssets.ShootInput(false);
            }
            AdjustAmmoAmount(-1);
            StartCoroutine(FireRate()); 
        }
    }
    public void AdjustAmmoAmount(int amount){///adjusting amount ammo on pickUp and when firing 
        currentAmmo+=amount;
        if(currentAmmo > max_ammo) currentAmmo= max_ammo;
        ammoText.text =currentAmmo.ToString("D3");//we want to display only 2 digits
    }
    public void SwitchWeapon(WeaponSO weaponPickUp){
        if(currentWeapon)Destroy(currentWeapon.gameObject);
        //if(currentWeaponSO != weaponPickUp)
        currentAmmo =0;//init ammo to not exceed magazine size
        max_ammo=weaponPickUp.magazineSize;
        AdjustAmmoAmount(weaponPickUp.magazineSize);
        currentWeaponSO =weaponPickUp;//swaping weapons
        
        firstPersonController.ChangeRoatationAmount(currentWeaponSO.rotationAmount);
        if (!currentWeaponSO.zoom)
        {
            zoom.enabled = false;
            camera.m_Lens.FieldOfView = currentWeaponSO.zoomOutValue;
            weaponCamera.fieldOfView=currentWeaponSO.zoomOutValue;
        }
        else firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
        currentWeapon=Instantiate(weaponPickUp.weaponPrefab,transform).GetComponent<Weapon>();
    }
    IEnumerator FireRate(){
        yield return new WaitForSeconds(currentWeaponSO.FireRate);
        firarateBlocked=false;
    }
 
    public void HandleZoom(){
        if(!currentWeaponSO.zoom)return;
        if(starterAssets.zoom){
            zoom.enabled = true;
            camera.m_Lens.FieldOfView=currentWeaponSO.zoomInValue;
            weaponCamera.fieldOfView=currentWeaponSO.zoomInValue;
            firstPersonController.ChangeRoatationAmount(currentWeaponSO.rotationAmount);
            // Debug.Log("zoom in");

        }else{
            zoom.enabled = false;
             camera.m_Lens.FieldOfView=currentWeaponSO.zoomOutValue;
             weaponCamera.fieldOfView=currentWeaponSO.zoomOutValue;
             firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
            // Debug.Log("not zoom");
        }
    }
}
