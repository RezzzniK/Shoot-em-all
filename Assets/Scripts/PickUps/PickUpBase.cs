using UnityEngine;
public abstract class PickUpBase : MonoBehaviour{
    const string PLAYER="Player";
    [SerializeField] float rotationSpeed=12f;
    ActiveWeapon activeWeapon;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag==PLAYER){
            activeWeapon=FindFirstObjectByType<ActiveWeapon>();
            PickUp(activeWeapon);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0f,rotationSpeed*Time.deltaTime,0f);
    }
    protected abstract void PickUp( ActiveWeapon activeWeapon);
}
