using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour, IWeaponBehavior
{
    public Weapon weaponData;
    public Transform muzzle;
    public float bulletSpeed = 10;

    public void Use(Vector2 direction)
    {
        Bullet bullet = BulletPoolManager.Instance.GetBullet();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        bullet.Fire(direction, bulletSpeed);
    }
}
