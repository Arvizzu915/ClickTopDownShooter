using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletTypeSO bulletSO;
    public Rigidbody2D rb;

    private void Update()
    {
        bulletSO.BulletTypeUpdate(this);
    }

    public void Fire(Vector2 direction)
    {
        bulletSO.Fire(this, direction);
    }

    public IEnumerator Lifetime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletSO.TriggerEnter(this, other);
    }

    public void Deactivate()
    {
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void ChangePrefab()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bulletSO.sprite;
        gameObject.GetComponent<CircleCollider2D>().radius = bulletSO.colliderRadius;
    }
}
