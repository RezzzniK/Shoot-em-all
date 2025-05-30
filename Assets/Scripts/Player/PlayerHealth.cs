using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int playerHealth = 10;
    [SerializeField] CinemachineVirtualCamera deathCamera;
    [SerializeField] Transform weaponCamera;//we need only transform from this camera to make transition to death camera
    [SerializeField] int deathCameraPriority = 20;
    [SerializeField] Image[] shieldBars;
  
    void Awake()
    {
        AdjustShieldBars(playerHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        Debug.Log("" + playerHealth);
        AdjustShieldBars(playerHealth);
        if (playerHealth <= 0)
        {
            //before we destroy our player GameObj lets unparent our weapon camera:
            weaponCamera.parent = null;
            //before we transfer our weapon camera to another virtual camera, if post-processing was toggled on
            //we will need to toggle on post-procsessing on new camera

            //also we need to change priority on new virtual camera that we will create later (weaponCamera has priority 10)
            deathCamera.Priority = deathCameraPriority;
            Destroy(this.gameObject);

        }

    }

    void AdjustShieldBars(int healthAmountToShow)
    {
        int counter=0;
        if (healthAmountToShow <= 0)
        {
            shieldBars[0].enabled = false;
        }
        else
        {
            foreach (var bar in shieldBars)
            {
                if (counter >= healthAmountToShow)
                {

                    bar.enabled = false;
                }
                counter++;
            }
            
        }
        
    }
   
}
