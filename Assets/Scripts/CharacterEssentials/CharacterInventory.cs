using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    private const int SLOTS = 10;
    private Player player;
    public GameObject currCharacter { get; private set; }
    public Character currCharacterScript { get; private set; }

    public GameObject[] Characters;
    public int currCharacterSlot { private set; get; }

    private int freeInvSlot;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();

        Characters = new GameObject[SLOTS];
        addCharacter(GameManager.Instance.CharacterManager.GetCharacter(30000));
        currCharacterScript = currCharacter.GetComponent<Character>();
    }

    public void OnCharacterUpdate(CharacterStats characterStats)
    {
        Characters[currCharacterSlot].GetComponent<Character>().characterStats = characterStats;
    }

    public void HandleCharacterCollect(int characterID)
    {
        int characterPosition = hasCharacter(characterID);

        if (characterPosition != -1)
        {
            Characters[characterPosition].GetComponent<Character>().AddExperience();
            return;
        }

        freeInvSlot = findNextEmptySlot();

        if (freeInvSlot == -1)
        {
            Debug.Log("Inventory Full");
        }
        else
        {
            addCharacter(characterID);
            Debug.Log("character added");
        }

    }

    public void addCharacter(GameObject character)
    {
        Characters[freeInvSlot] = character;
    }

    public void addCharacter(int characterID)
    {
        Characters[freeInvSlot] = GameManager.Instance.CharacterManager.GetCharacter(characterID);
    }

    public void removeCharacter(int itemSlot)
    {
        Characters[itemSlot] = null;
    }

    public int hasCharacter(Character character) //returns position if it has character
    {
        for (int i = 0; i < SLOTS; i++)
        {
            if (Characters[i] != null)
            {
                Character loopCharacter = Characters[i].GetComponent<Character>();
                if (loopCharacter.Equals(character))
                    return i;
            }
            else
                return -1; //populated slots will always be adjacent to eachother
        }
        return -1;
    }

    public int hasCharacter(int characterID)
    {
        for (int i = 0; i < SLOTS; i++)
        {
            if (Characters[i] != null)
            {
                Character loopCharacter = Characters[i].GetComponent<Character>();
                if (loopCharacter.ID == characterID)
                    return i;
            }
            else
                return -1;
        }
        return -1;
    }

    public int findNextEmptySlot()
    {
        for (int i = 0; i < SLOTS; i++)
        {
            if (Characters[i] == null)
            {
                return i;
            }
        }

        return -1;
    }

    public void switchCharacterPosition(int slot1, int slot2)
    {
        GameObject heldCharacter = Characters[slot1];
        Characters[slot1] = Characters[slot2];
        Characters[slot2] = heldCharacter;
    }

    public void Reset()
    {
        for (int i = 0; i < SLOTS; i++)
        {
            Characters[i] = null;
        }
    }

    public void ShowInventory()
    {
        for (int i = 0; i < SLOTS; i++)
        {
            Debug.Log(Characters[i]);
        }
    }

    public void switchCharacter(int slot)
    {
        currCharacter.GetComponent<Character>().SwitchDestroy();
        Debug.Log(Characters[0].GetComponent<Character>().characterStats.RateOfFire);
        Debug.Log(Characters[0].GetComponent<Character>().characterStats.baseStatsSet);

        currCharacter = Instantiate(Characters[slot], transform.position, transform.rotation, transform);
        currCharacterSlot = slot;

        currCharacterScript = currCharacter.GetComponent<Character>();
        Messenger<Character>.Broadcast(GameEvent.CHARACTER_SWITCHED, currCharacterScript);
    }
}
