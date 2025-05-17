using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathCamera;
    [SerializeField] Transform weaponCamera;//we need only transform from this camera to make transition to death camera
    [SerializeField] int deathCameraPriority = 20;
     public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            //before we destroy our player GameObj lets unparent our weapon camera:
            weaponCamera.parent = null;
            //before we transfer our weapon camera to another virtual camera, if post-processing was toggled on
            //we will need to toggle on post-procsessing on new camera

            //also we need to change priority on new virtual camera that we will create later (weaponCamera has priority 10)
            deathCamera.Priority =deathCameraPriority ;
            Destroy(this.gameObject);

        }

    }
   
}
