using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private BulletTypeSO currentBulletType;

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
        newBullet.bulletSO = currentBulletType;
        newBullet.ChangePrefab();
        pool.Add(newBullet);
        return newBullet;
    }

    public void ChangeBulletTypeSO(BulletTypeSO bulletTypeSO)
    {
        currentBulletType = bulletTypeSO;
        foreach (var bullet in pool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.bulletSO = bulletTypeSO;
                bullet.ChangePrefab();
            }
        }
    }
}
