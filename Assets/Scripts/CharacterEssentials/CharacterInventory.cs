using System;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    private const int SLOTS = 10;
    private int numCharacters;

    private MasterPlayer player;
    public GameObject currCharacter { get; private set; }
    public Character currCharacterScript { get; private set; }

    public GameObject[] Characters = new GameObject[SLOTS];
    public int currCharacterSlot { private set; get; }

    private int freeInvSlot;

    public void HandleCharacterCollect(int characterID)
    {
        int characterPosition = hasCharacter(characterID);

        if (characterPosition != -1)
        {
            Characters[characterPosition].GetComponent<Character>().addExperience();
            return;
        } 
       
        addCharacter(characterID);
        Debug.Log("character added");
        

    }

    //Handle the connections necessary when a player gets a new character.
    public void addCharacter(int characterID)
    {
        if (numCharacters >= SLOTS)
        {
            Debug.Log("Inventory full");
            return;
        }

        GameObject newCharacter = Instantiate(GameManager.Instance.GameCharacterLibrary._characterLibrary[characterID]);
        Characters[numCharacters] = newCharacter;
        newCharacter.GetComponent<Character>().setCharacterActive(false);
        newCharacter.GetComponent<Character>().prepareCharacter(player.InputControl, newCharacter.transform);


        numCharacters += 1;

    }

    public void removeCharacter(Character character)
    {
        int i = 0;
        Type type = character.GetType(); //abstract class, we need to know which character/subclass

        while (i < numCharacters && (Characters[i].GetComponent<Character>().type))
        {

        }
        Characters[itemSlot] = null;
        //reorganize the list
        numCharacters -= 1;
    }

    //returns position of character or negative one if it is not in the array.
    public int hasCharacter(Character character)
    {
        for (int i = 0; i < numCharacters; i++)
        {
            Character loopCharacter = Characters[i].GetComponent<Character>();
            if (loopCharacter.Equals(character))
                return i;
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
