using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GamePassiveItemLibrary : GameLibrary
{

    private Dictionary<int, PassiveItem> passiveItemLibrary;

    public override void DecodeJSON()
    {
        passiveItemLibrary = new Dictionary<int, PassiveItem>();

        string m_PassiveItemsPath = Application.dataPath + "/PassiveItems.json";
        string json;

        var fileStream = new FileStream(m_PassiveItemsPath, FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            while ((json = streamReader.ReadLine()) != null)
            {
                PassiveItem currPassiveItem = JsonUtility.FromJson<PassiveItem>(@json);
                passiveItemLibrary[currPassiveItem.ID] = currPassiveItem;

            }
        }
    }

    private void onPassiveItemCollected(ref Character character, int ItemID)
    {
        character.CharacterStats.MaxHealth += passiveItemLibrary[ItemID].maxHealth;

        character.CharacterStats.MaxEnergy += passiveItemLibrary[ItemID].maxEnergy;
        character.CharacterStats.EnergyRegen += passiveItemLibrary[ItemID].energyRegen;
        character.CharacterStats.ShootEnergyCost += passiveItemLibrary[ItemID].shootEnergyCost;
        character.CharacterStats.SpecialMovementCost += passiveItemLibrary[ItemID].specialMovementCost;
        character.CharacterStats.ShieldEnergyRate += passiveItemLibrary[ItemID].shieldEnergyRate;

        character.CharacterStats.RateOfFire /= passiveItemLibrary[ItemID].rateOfFire; //rate of fire will always be handled by division;
        character.CharacterStats.DamageDealt += passiveItemLibrary[ItemID].damageDealt;
        character.CharacterStats.MovementSpeed += passiveItemLibrary[ItemID].movementSpeed;
    }

}