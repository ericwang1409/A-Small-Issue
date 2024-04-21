using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DayTracker : MonoBehaviour
{
    private int _day = 0;

    public GameObject spy;
    public GameObject scientist;
    public GameObject grunt;
    public GameObject townNPC;
    public GameObject endScreenTrigger;

    public event Action DayChanged;

    public int Day
    {
        get { return _day; }
        set
        {
            if (_day != value)
            {
                _day = value;
                // Optional: Invoke the DayChanged event
                DayChanged?.Invoke();
                // You can also call other methods here or execute any logic needed
                OnDayChanged();
            }
        }
    }

    private void OnDayChanged()
    {
        Debug.Log($"Day changed to: {_day}");

        // spy.transform.position = new Vector3(0, 0, 0);
    }

    public static DayTracker Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }

    public void InstantiateAgain()
    {
        // starting position in awake
        if (DayTracker.Instance.Day < 3 && AudioManager.i.musicPlayer.clip != AudioManager.i.dayMusicTracks[DayTracker.Instance.Day])
            AudioManager.i.PlayDailyMusic();

        // check day and scene name
        if (DayTracker.Instance.Day == 0 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Library")
        {
            spy.SetActive(true);
            spy.transform.position = new Vector3(0, 5, 0);
        }
        else if (DayTracker.Instance.Day == 1 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Library")
        {
            spy.SetActive(true);
            spy.transform.position = new Vector3(4.4f, 3.6f, 0);
        }
        else if (DayTracker.Instance.Day == 2 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Starting")
        {
            spy.SetActive(true);
            spy.transform.position = new Vector3(-3.2f, 0.8f, 0);
        }
        else if (DayTracker.Instance.Day == 3 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Starting")
        {
            Debug.Log("Day 3");
            spy.SetActive(true);
            endScreenTrigger.SetActive(true);
            spy.transform.position = new Vector3(39, 4.4f, 0);
        }
        else
        {
            spy.SetActive(false);
        }
    }

    // Constructor or other methods
}

