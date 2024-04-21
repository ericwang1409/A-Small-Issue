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
    public GameObject coffeeLady;
    public GameObject townNPC;
    public GameObject personalComputer;
    public GameObject endScreenTrigger;
    public GameObject labComputer;

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
       //Debug.Log($"Day changed to: {_day}");

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
        else if ((DayTracker.Instance.Day == 2 || DayTracker.Instance.Day == 3) && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Starting")
        {
            spy.SetActive(true);
            spy.transform.position = new Vector3(-3.2f, 0.8f, 0);
        }
        else if (DayTracker.Instance.Day == 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Starting")
        {
            spy.SetActive(true);
            endScreenTrigger.SetActive(true);
            spy.transform.position = new Vector3(39, 4.4f, 0);
        }
        else
        {
            spy.SetActive(false);
        }

        // scientist
        if (DayTracker.Instance.Day >= 0 && DayTracker.Instance.Day <= 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LabTopFloor")
        {
            scientist.SetActive(true);
            scientist.transform.position = new Vector3(-4.5f, 3.8f, 0);
        }
        else
        {
            scientist.SetActive(false);
        }

        // grunt
        if (DayTracker.Instance.Day >= 0 && DayTracker.Instance.Day <= 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LabBottomFloor")
        {
            grunt.SetActive(true);
            grunt.transform.position = new Vector3(-0.5f, -0.2f, 0);
        }
        else
        {
            grunt.SetActive(false);
        }

        if (DayTracker.Instance.Day >= 0 && DayTracker.Instance.Day <= 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "CoffeeShop")
        {
            coffeeLady.SetActive(true);
            coffeeLady.transform.position = new Vector3(3.5f, 3f, 0);
        }
        else
        {
            coffeeLady.SetActive(false);
        }

        if (DayTracker.Instance.Day >= 0 && DayTracker.Instance.Day <= 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "PlayerHouse")
        {
            personalComputer.SetActive(true);
            personalComputer.transform.position = new Vector3(-4.5f, 2.46f, 0);
        }
        else
        {
            personalComputer.SetActive(false);
        }

        if (DayTracker.Instance.Day >= 0 && DayTracker.Instance.Day <= 4 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LabBottomFloor")
        {
            labComputer.SetActive(true);
            labComputer.transform.position = new Vector3(2.5f, 5.5f, 0);
        }
        else
        {
            labComputer.SetActive(false);
        }
    }

    // Constructor or other methods
}

