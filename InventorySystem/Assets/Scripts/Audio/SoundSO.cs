using System;
using UnityEngine;

namespace InventorySystem.Sound
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Sound SO", fileName = "SoundSO")]
    public class SoundSO : ScriptableObject
    {
        public Sounds[] audioList;
    }

    [Serializable]
    public struct Sounds
    {
        public SoundType soundType;
        public AudioClip audio;
    }
}
