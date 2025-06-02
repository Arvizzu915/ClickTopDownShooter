using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    public Weapon currentWeapon;

    private float cooldown = 0;
    private bool attacking = false;

    private Vector2 attackingDirection;

    private void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
        
        if (attacking && cooldown <= 0)
        {
            UseWeapon(attackingDirection, this);
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public void UseWeapon(Vector2 direction, WeaponHolder playerScript)
    {
        cooldown = currentWeapon.fireRate;
        currentWeapon?.Use(direction, playerScript);
    }

    public void ShootInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
            attacking = true;
            Debug.Log(currentWeapon);
        }

        if (ctx.canceled)
        {
            attacking = false;
        }
    }

    public void ShootDirection(InputAction.CallbackContext ctx)
    {
        attackingDirection = ctx.ReadValue<Vector2>();
    }
}
