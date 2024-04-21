using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicPlayer;
    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] public List<AudioClip> dayMusicTracks = new List<AudioClip>();

    public static AudioManager i {get; private set; }
    private void Awake() {
        i = this;
    }

    void Start() {
        PlayDailyMusic();
    }

    public void PlayDailyMusic() {
        int currentDay = DayTracker.Instance.Day; 
        //Debug.Log("current day:" + currentDay);
        AudioClip clip = SelectMusicForDay(currentDay);
        PlayMusic(clip, true);
    }

    private AudioClip SelectMusicForDay(int day) {

        Debug.Log("select called");
        if (dayMusicTracks.Count == 0) {
            //Debug.LogWarning("No music tracks are assigned");
            return null;
        }
        
        if (day == 0 && dayMusicTracks.Count > 0) {
            //Debug.LogWarning("Playing day 1 music");
            return dayMusicTracks[0];
        }
        else if (day == 1 && dayMusicTracks.Count > 1) {
            //Debug.LogWarning("Playing day 2 music");
            return dayMusicTracks[1];
        }
        else if (day >= 2 && dayMusicTracks.Count > 2) {
           // Debug.LogWarning("Playing day 3+ music");
            return dayMusicTracks[2];
        }

        return dayMusicTracks[dayMusicTracks.Count - 1]; 
    }

    public void PlayMusic(AudioClip clip, bool loop = true) {
        if (clip == null) {return; }

        musicPlayer.clip = clip;
        musicPlayer.loop = loop; 
        musicPlayer.Play();
    }
}
