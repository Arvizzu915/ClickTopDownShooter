using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public abstract class Weapon : ScriptableObject, IWeapon
{
    [SerializeField] public string weaponName;
    [SerializeField] public Sprite weaponSprite;
    [SerializeField] public float damage;
    [SerializeField] public float fireRate;


    public abstract void Use(Vector2 direction, WeaponHolder playerScript);
}


