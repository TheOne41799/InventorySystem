using System;
using UnityEngine;

namespace InventorySystem.Sound
{
    public class AudioService
    {
        private SoundScriptableObject soundScriptableObject;
        private AudioSource audioEffects;
        private AudioSource backgroundMusic;

        public AudioService(SoundScriptableObject soundScriptableObject, AudioSource audioEffectSource, AudioSource bgMusicSource)
        {
            this.soundScriptableObject = soundScriptableObject;
            audioEffects = audioEffectSource;
            backgroundMusic = bgMusicSource;
            PlaybackgroundMusic(SoundType.BACKGROUND_MUSIC, true);
        }

        public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);

            if (clip != null)
            {
                audioEffects.loop = loopSound;
                audioEffects.clip = clip;
                audioEffects.PlayOneShot(clip);
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);

            if (clip != null)
            {
                backgroundMusic.loop = loopSound;
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds sound = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);

            if (sound.audio != null)
                return sound.audio;
            return null;
        }
    }
}