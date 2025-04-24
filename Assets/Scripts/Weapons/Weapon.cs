using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] public string weaponName;
    [SerializeField] public float damage;
    [SerializeField] public float fireRate;
    [SerializeField] public GameObject projectilePrefab;
}

public interface IWeaponBehavior
{
    void Use(Vector2 direction);
}
