using System;

[Serializable]
public class PassiveItem
{
    public string itemName;

    public string description;

    public int ID;

    public float maxHealth;

    public float maxEnergy;
    public float energyRegen;
    public float shootEnergyCost;
    public float specialMovementCost;
    public float shieldEnergyRate;

    public float rateOfFire;
    public float damageDealt;
    public float movementSpeed;

    public bool characterModelChange;

}
