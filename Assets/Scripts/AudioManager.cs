using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] AudioSource musicPlayer;
    [SerializeField] AudioSource sfxPlayer;

    public static AudioManager j {get; private set; }
    private void Awake(){
        j = this;
    }

    public void PlayMusic(AudioClip clip, bool loop = true) {
        if (clip == null) {return; }

        musicPlayer.clip = clip;
        musicPlayer.loop = loop; 
        musicPlayer.Play();
    }
}
