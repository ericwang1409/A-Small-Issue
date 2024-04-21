using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// This script runs permanently, is basically used...
// to decide which state the game is in...
// it can hold globals

// List of game states
public enum GameState { FreeRoam, Task, Dialogue, Cutscene, Newspaper, Paused }

public class GameController : MonoBehaviour
{   
    // playerController state, used in freeroam
    [SerializeField] PlayerController playerController;
    // [SerializeField] TaskController taskController;
    [SerializeField] DialogueManager dialogueManager;
    GameState stateBeforePause;
    [SerializeField] NewspaperText newspaperManager;
    [SerializeField] Camera worldCamera;

    public GameState state;

    public int day = 0;
    public int gameStage = 0;
    public string playerName = "Guest";
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.OnShowDialogue += () => {
            state = GameState.Dialogue;
        };

        DialogueManager.Instance.OnCloseDialogue += () => {
            if (state == GameState.Dialogue) {
            state = GameState.FreeRoam;
            }
        };  

        newspaperManager.OnNewspaperFinished += EndNewspaper;
    }

    void EndNewspaper()
    {
        state = GameState.FreeRoam;
        newspaperManager.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    public void PauseGame(bool pause) {
        if (pause == true) {
            stateBeforePause = state;
            state = GameState.Paused;
        } else {
            state = stateBeforePause;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.FreeRoam) {
            // If in free roam, pass game updates to playerController script
            playerController.HandleUpdate();
        } else if (state == GameState.Task) {
            // taskController.HandleUpdate();
        } else if (state == GameState.Dialogue) {
            DialogueManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Newspaper)
        {
            newspaperManager.gameObject.SetActive(true);
            worldCamera.gameObject.SetActive(false);
            newspaperManager.HandleUpdate();
        }
    }

    public static GameController Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }


    public void StartCutsceneState()
    {
        state = GameState.Cutscene;
    }

    public void StartFreeRoamState()
    {
        state = GameState.FreeRoam;
    }
}
