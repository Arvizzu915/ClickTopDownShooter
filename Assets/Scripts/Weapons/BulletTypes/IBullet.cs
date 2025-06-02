using UnityEngine;

public interface IBullet
{
    void Fire(Bullet bulletScript, Vector2 direction);

    void TriggerEnter(Bullet bulletScript, Collider2D other);
}
