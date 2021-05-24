using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class Character : ScriptableObject
{
    public string fullName;
    public Sprite sprite;
    public enum CharacterType { Family, Friend, Stranger };
    public CharacterType characterType;
}
