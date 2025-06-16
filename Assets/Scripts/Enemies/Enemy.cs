using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;
    [SerializeField] Rigidbody2D rb;

    Vector2 direction;

    private void Update()
    {
        direction = PlayerMovement.singleton.transform.position;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * enemySO.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(enemySO.damage);
        }
    }
}
