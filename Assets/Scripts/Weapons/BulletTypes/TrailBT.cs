using UnityEngine;

[CreateAssetMenu(fileName = "Bullet")]
public class TrailBT : BulletTypeSO
{
    [SerializeField] private float lifetime;
    private float grow;

    public override void Fire(Bullet bulletScript, Vector2 direction)
    {
        bulletScript.transform.localScale = new Vector3(1, 1, 1);
        grow = bulletScript.transform.localScale.x / lifetime;
        bulletScript.gameObject.SetActive(true);
        bulletScript.rb.linearVelocity = direction.normalized * speed;
        bulletScript.StartCoroutine(bulletScript.Lifetime(lifetime));
    }

    public override void TriggerEnter(Bullet bulletScript, Collider2D other)
    {
        //apply damage to enemy

    }

    public override void BulletTypeUpdate(Bullet bullet)
    {
        Transform bulletTransform = bullet.transform;
        bulletTransform.localScale = new Vector3(bulletTransform.localScale.x - grow * Time.deltaTime, bulletTransform.localScale.y - grow * Time.deltaTime, bulletTransform.localScale.z - grow * Time.deltaTime);
    }
}
