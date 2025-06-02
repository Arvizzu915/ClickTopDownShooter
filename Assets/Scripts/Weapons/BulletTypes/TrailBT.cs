using UnityEngine;

[CreateAssetMenu(fileName = "Bullet")]
public class TrailBT : BulletTypeSO
{
    [SerializeField] private float lifetime;

    public override void Fire(Bullet bulletScript, Vector2 direction)
    {
        bulletScript.gameObject.SetActive(true);
        bulletScript.rb.linearVelocity = direction.normalized * speed;
        bulletScript.StartCoroutine(bulletScript.Lifetime(lifetime));
    }

    public override void TriggerEnter(Bullet bulletScript, Collider2D other)
    {
        //apply damage to enemy
    }
}
