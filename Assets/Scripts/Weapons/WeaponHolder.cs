using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private IWeaponBehavior currentWeapon;

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy((currentWeapon as MonoBehaviour).gameObject);
        }

        GameObject weaponInstance = Instantiate(weaponPrefab, transform);
        currentWeapon = weaponInstance.GetComponent<IWeaponBehavior>();
    }

    public void UseWeapon(Vector2 direction)
    {
        currentWeapon?.Use(direction);
    }
}
