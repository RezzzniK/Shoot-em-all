using System.Collections;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
public class ActiveWeapon : MonoBehaviour{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField]Image zoom;
    [SerializeField] GameObject followCamera;
    StarterAssetsInputs starterAssets;
    FirstPersonController firstPersonController;
    Animator animator;
    Weapon currentWeapon;
    CinemachineVirtualCamera camera;
    float defaultRotationSpeed=1f;
    bool firarateBlocked=false;
    const string KICK_BACK_STRING="KickBack";                         
    void Awake(){
        starterAssets=GetComponentInParent<StarterAssetsInputs>();
        animator=GetComponent<Animator>(); 
        camera=followCamera.GetComponent<CinemachineVirtualCamera>();
        firstPersonController=GetComponentInParent<FirstPersonController>();
        firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
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
        firstPersonController.ChangeRoatationAmount(weaponSO.rotationAmount);
        if (!weaponSO.zoom){
            zoom.enabled = false;
            camera.m_Lens.FieldOfView=weaponSO.zoomOutValue;
        }else{
             firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
        }
        currentWeapon=Instantiate(weaponPickUp.weaponPrefab,transform).GetComponent<Weapon>();
    }
    public void HandleZoom(){
        if(!weaponSO.zoom)return;
        if(starterAssets.zoom){
            zoom.enabled = true;
            camera.m_Lens.FieldOfView=weaponSO.zoomInValue;
            firstPersonController.ChangeRoatationAmount(weaponSO.rotationAmount);
            Debug.Log("zoom in");

        }else{
            zoom.enabled = false;
             camera.m_Lens.FieldOfView=weaponSO.zoomOutValue;
             firstPersonController.ChangeRoatationAmount(defaultRotationSpeed);
            Debug.Log("not zoom");
        }
    }
}
