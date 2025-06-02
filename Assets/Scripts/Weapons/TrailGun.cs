using UnityEngine;

[CreateAssetMenu(fileName = "TrailGun")]
public class TrailGun : Weapon
{
    [SerializeField] private float bulletSpeed;
    
    public override void Use(Vector2 direction, WeaponHolder playerScript)
    {
        Bullet bullet = BulletPoolManager.Instance.GetBullet();
        bullet.transform.position = playerScript.transform.position;
        bullet.transform.rotation = playerScript.transform.rotation;
        bullet.Fire(direction);
    }
}
