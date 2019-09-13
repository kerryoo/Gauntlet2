using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CharacterLibrary : Library
{
    [SerializeField] GameObject[] _characterModels;

    private readonly int NUMBER_OF_CHARACTERS = 8;
    private const int CHARACTER_ID_BUFFER = 10000;
    private Dictionary<int, Character> _characterLibrary;

    public override void DecodeJSON()
    {
        _characterLibrary = new Dictionary<int, Character>();

        string m_PassiveItemsPath = Application.dataPath + "/PassiveItems.json";

        var fileStream = new FileStream(m_PassiveItemsPath, FileMode.Open, FileAccess.Read);

        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {

        }
    }

    private Character buildCharacter(ref StreamReader streamReader, Character character)
    {
        string json = streamReader.ReadLine();
        CharacterStats currStats = JsonUtility.FromJson<CharacterStats>(@json);
    }
}