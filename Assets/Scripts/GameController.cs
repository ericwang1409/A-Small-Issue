using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script runs permanently, is basically used...
// to decide which state the game is in...
// it can hold globals

// List of game states
public enum GameState { FreeRoam, Task, Dialogue, Cutscene }

public class GameController : MonoBehaviour
{   
    // playerController state, used in freeroam
    [SerializeField] PlayerController playerController;
    // [SerializeField] TaskController taskController;
    [SerializeField] DialogueManager dialogueManager;
    GameState state;
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
