using UnityEngine;

public abstract class BulletTypeSO : ScriptableObject, IBullet
{
    public float colliderRadius;
    public Sprite sprite;
    public float speed;

    public abstract void Fire(Bullet bulletScript, Vector2 direction);

    public abstract void TriggerEnter(Bullet bulletScript, Collider2D other);

    public virtual void BulletTypeUpdate(Bullet bullet)
    {

    }
}
