using UnityEngine;
using InventorySystem.Sound;
using InventorySystem.Player;

namespace InventorySystem.Main
{
    public class GameService : MonoBehaviour
    {
        /*private AudioService audioService;
        private PlayerService playerService;

        [SerializeField] private SoundSO soundScriptableObject;
        [SerializeField] private PlayerView playerView;

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
            playerService = new PlayerService(playerView);
        }

        private void InjectDependencies()
        {
            playerService.Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("The money player has : " + playerService.GetAvailableMoney());
            }            
        }*/
    }
}
