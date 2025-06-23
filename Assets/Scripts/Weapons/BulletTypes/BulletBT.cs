using UnityEngine;

[CreateAssetMenu(fileName = "Bullet")]
public class BulletBT : BulletTypeSO
{
    [SerializeField] private float lifetime;

    public override void Fire(Bullet bulletScript, Vector2 direction)
    {
        bulletScript.gameObject.SetActive(true);
        Debug.Log("ghghgghgghghg");
        bulletScript.rb.linearVelocity = direction * speed;
        bulletScript.StartCoroutine(bulletScript.Lifetime(lifetime));
    }

    public override void TriggerEnter(Bullet bulletScript, Collider2D other)
    {
        bulletScript.Deactivate();
    }
}
