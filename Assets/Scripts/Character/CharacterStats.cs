using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float MaxHealth { get; private set; }
    public float HealthRemaining { get; private set; }

    public float MaxEnergy { get; private set; }
    public float EnergyRemaining { get; private set; }
    public float EnergyRegen { get; private set; }
    public float ShootEnergyCost { get; private set; }
    public float SpecialMovementCost { get; private set; }
    public float ShieldEnergyRate { get; private set; }

    public float RateOfFire { get; private set; }
    public float DamageDealt { get; private set; }
    public float MovementSpeed { get; private set; }

    CharacterStats(float maxHealth, float maxEnergy, float energyRegen, float shootEnergyCost, 
        float specialMovementCost, float shieldEnergyRate, float rateOfFire,
        float damageDealt, float movementSpeed)
    {
        MaxHealth = HealthRemaining = maxHealth;
        MaxEnergy = EnergyRemaining = maxEnergy;
        EnergyRegen = energyRegen;
        ShootEnergyCost = shootEnergyCost;
        SpecialMovementCost = specialMovementCost;
        ShieldEnergyRate = shieldEnergyRate;

        RateOfFire = rateOfFire;
        DamageDealt = damageDealt;
        MovementSpeed = movementSpeed;

    }
    


    void Update()
    {
        if (EnergyRemaining < MaxEnergy)
            EnergyRemaining += EnergyRegen * Time.deltaTime;

        if (EnergyRemaining > MaxEnergy - 0.1)
            EnergyRemaining = MaxEnergy;
    }

    public void TakeDamage(float damageAmount)
    {
        HealthRemaining -= damageAmount;

        if (HealthRemaining <= 0)
            Die();
    }

    public void RemoveShieldEnergy()
    {
        EnergyRemaining -= ShieldEnergyRate * Time.deltaTime;
    }

    public void RemoveShootEnergy()
    {
        EnergyRemaining -= ShootEnergyCost;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }



}