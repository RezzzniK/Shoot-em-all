using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
     public void TakeDamage(int damageAmount)
    {
       
        playerHealth -= damageAmount;


        if (playerHealth <= 0)
        {
          Destroy(this.gameObject);

        }

    }

   
}
