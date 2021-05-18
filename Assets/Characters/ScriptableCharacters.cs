using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SocicalCircle
{
    [CreateAssetMenu(fileName = "Data", menuName = "Socical/Character")]
    public class ScriptableCharacters : ScriptableObject
    {
        public Sprite characterSprite;
        public CharacterType characterType;
        public AudioClip voice;
    }

}
