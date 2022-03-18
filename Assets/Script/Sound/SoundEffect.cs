using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamejam.Sound
{
    public class SoundEffect : MonoBehaviour
    {
        public AudioSource audioSource;

        
        
        public void PlaySoundFX()
        {
            audioSource.Play();
            
        }
    }
}
