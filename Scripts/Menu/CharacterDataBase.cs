using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


/*[CreateAssetMenu]
public class CharacterDataBase : ScriptableObject
{
    public Character[] character;

    public int CharacterNum
    {
        get 
        { 
            return character.Length;
            Debug.Log("the number is :" +  character.Length);
        }
        
    }

    public Character GetCharacter(int index)
    {
        return character[index];
    }
}
*/
[CreateAssetMenu]
public class CharacterDataBase : ScriptableObject
{
    public Character[] character;
    public int selectedOption; // Store selected option here

    public int CharacterNum => character.Length;

    public Character GetCharacter(int index)
    {
        return character[index];
    }
}
