using System.Collections;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IWeaponBehavior
{
    public Weapon weaponData;

    public PolygonCollider2D hitboxCollider;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hitboxCollider.enabled = false;
    }

    public void Use(Vector2 direction)
    {
        animator.SetTrigger("Attack");
    }

    // Called via Animation Event
    public void DisableHitbox()
    {
        animator.SetBool("Attack", false);
    }
}
