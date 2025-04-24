using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private List<Bullet> pool = new();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            pool.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        foreach (var bullet in pool)
        {
            if (!bullet.gameObject.activeInHierarchy)
                return bullet;
        }

        // Expand pool if needed
        Bullet newBullet = Instantiate(bulletPrefab, transform);
        newBullet.gameObject.SetActive(false);
        pool.Add(newBullet);
        return newBullet;
    }
}
