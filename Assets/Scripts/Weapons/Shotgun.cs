using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun")]
public class Shotgun : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public BulletTypeSO bulletType;
    [SerializeField] private float bulletSpeed;

    public override void Use(Vector2 direction, WeaponHolder playerScript)
    {
        for (int i = -3; i < 4; i++)
        {

            Bullet bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = playerScript.transform.position;
            bullet.transform.rotation = playerScript.transform.rotation;
            bullet.rb.linearDamping = 3f;
            bullet.transform.Rotate(0,0,i*-5);
            if (Mathf.Abs(direction.x)==1)
            {
                direction.y = i*.1f;
            }
            else
            {
                direction.x = i*.1f;
            }
            
            bullet.Fire(direction);
        }
        
    }

    public override void ChangeBulletType()
    {
        BulletPoolManager.Instance.ChangeBulletTypeSO(bulletType);
    }
}
