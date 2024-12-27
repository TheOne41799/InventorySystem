using UnityEngine;
using InventorySystem.Sound;

namespace InventorySystem.Main
{
    public class GameService : MonoBehaviour
    {
        private AudioService audioService;

        [SerializeField] private SoundSO soundScriptableObject;

        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource bgMusicSource;


        private void Start()
        {
            InitializeServices();
            InjectDependencies();
        }

        private void InitializeServices()
        {
            audioService = new AudioService(soundScriptableObject, sfxSource, bgMusicSource);
        }

        private void InjectDependencies()
        {
            
        }
    }
}
