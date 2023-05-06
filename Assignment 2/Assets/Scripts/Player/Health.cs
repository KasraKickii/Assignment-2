using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerVoidEvent();
public delegate void PlayerBoolEvent(bool value);

/// <summary>
/// Adds health to a player.
/// </summary>
public class Health : MonoBehaviour
{
    public event PlayerVoidEvent OnDeath;
    public event PlayerBoolEvent OnDamaged;
    public event PlayerVoidEvent OnFullHealth;
    public event PlayerVoidEvent OnHealed;

    [SerializeField] private int maxHealth;
    [SerializeField] private float maxInvincibilityTime;
    private float invincibilityTime;

    /// <summary>
    /// Current health of the player.
    /// </summary>
    public int CurrentHealth
    {
        get; private set;
    }

    /// <summary>
    /// Returns true if the player can be damaged.
    /// </summary>
    /// <returns></returns>
    public bool CanDamage() //Only takes invincibility frames into account atm, but can be expanded upon if necessary.
    {
        return invincibilityTime <= 0;
    }

    /// <summary>
    /// Damages the player and sets invincibility time. If the player dies, an OnDeath event will be called.
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        if (CurrentHealth <= 0)
        {
            invincibilityTime = Time.deltaTime * 2; //Prevents the player from being damaged immediately after respawning (Which did in fact happen at times)
            OnDeath?.Invoke();
        }
        else
        {
            invincibilityTime = maxInvincibilityTime;
        }
    }

    /// <summary>
    /// Tries to damage the player. If the player survives, an OnDamaged event will be called.
    /// </summary>
    /// <param name="damage"></param>
    public void TryDamage(int damage)
    {
        bool canDamage = CanDamage();
        if (canDamage)
        {
            Damage(damage);
            if (CurrentHealth > 0)
            {
                OnDamaged?.Invoke(canDamage);
            }
        }
    }

    /// <summary>
    /// Heals the player. If the player is at full health, an OnFullHealth event will be called.
    /// </summary>
    /// <returns>True if the player reaches full health.</returns>
    /// <param name="damage"></param>
    public bool Heal(int damage)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + damage, maxHealth);

        if (CurrentHealth >= maxHealth)
        {
            OnFullHealth?.Invoke();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Tries to heal the player. If the player recieves health, an OnHealed event will be called.
    /// </summary>
    /// <param name="damage"></param>
    public void TryHeal(int damage)
    {
        if (!Heal(damage))
        {
            OnHealed?.Invoke();
        }
    }

    /// <summary>
    /// Reduces invincibility time if it's active.
    /// </summary>
    private void InvincibilityTimer()
    {
        if (invincibilityTime > 0)
        {
            invincibilityTime -= Time.deltaTime;
        }
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        InvincibilityTimer();
    }
}
