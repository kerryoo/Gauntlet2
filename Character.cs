using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private CharacterState _currCharacterState;
    private InputControl _inputControl;

    public CharacterStats CharacterStats;
    public GameObject CharacterModel;

    public void handleInput()
    {
        _currCharacterState.handleInput();
    }

    void Update()
    {
        if (CharacterStats.EnergyRemaining < CharacterStats.MaxEnergy)
            CharacterStats.EnergyRemaining += CharacterStats.EnergyRegen * Time.deltaTime;

        if (CharacterStats.EnergyRemaining > CharacterStats.MaxEnergy - 0.001)
            CharacterStats.EnergyRemaining = CharacterStats.MaxEnergy;
    }

    public void TakeDamage(float damageAmount)
    {
        CharacterStats.HealthRemaining -= damageAmount;

        if (CharacterStats.HealthRemaining <= 0)
            Die();
    }

    public void RemoveShieldEnergy()
    {
        CharacterStats.EnergyRemaining -= CharacterStats.ShieldEnergyRate * Time.deltaTime;
    }

    public void RemoveShootEnergy()
    {
        CharacterStats.EnergyRemaining -= CharacterStats.ShootEnergyCost;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    
}
