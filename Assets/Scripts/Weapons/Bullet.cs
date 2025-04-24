using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float lifetime = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction, float speed)
    {
        gameObject.SetActive(true);
        rb.linearVelocity = direction.normalized * speed;
        StartCoroutine(Lifetime(lifetime));
    }

    IEnumerator Lifetime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // hit logic here
        Deactivate();
    }

    private void Deactivate()
    {
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
