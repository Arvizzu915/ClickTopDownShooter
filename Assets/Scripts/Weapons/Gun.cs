using UnityEngine;

[CreateAssetMenu(fileName = "Gun")]
public class Gun : Weapon
{
    [SerializeField] public BulletTypeSO bulletType;
    [SerializeField] private float bulletSpeed;
    
    public override void Use(Vector2 direction, WeaponHolder playerScript)
    {
        Bullet bullet = BulletPoolManager.Instance.GetBullet();
        bullet.transform.position = playerScript.transform.position;
        bullet.transform.rotation = playerScript.transform.rotation;
        bullet.Fire(direction);
    }

    public override void ChangeBulletType()
    {
        BulletPoolManager.Instance.ChangeBulletTypeSO(bulletType);
    }
}
