using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// realnpc_0 (purple shirt guy) controller

public class realnpc_0controller : MonoBehaviour, Interactable
{
    // realnpc_0 displays its dialogue when interacted with
    [SerializeField] Dialogue dialogue0;
    [SerializeField] Dialogue dialogue1;
    [SerializeField] Dialogue dialogue2;
    [SerializeField] Dialogue dialogue3;

    private List<Dialogue> dialoguesList = new();
    [SerializeField] List<Vector2> movementPattern;
    [SerializeField] float timeBetweenPattern;
    [SerializeField] List<Sprite> sprites;

    NPCState state;
    float idleTimer = 0f;
    int currentPattern = 0;

    SpriteAnimator spriteAnimator;
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        spriteAnimator = new SpriteAnimator(sprites, GetComponent<SpriteRenderer>());
        spriteAnimator.Start();

        dialoguesList.Add(dialogue0);
        dialoguesList.Add(dialogue1);
        dialoguesList.Add(dialogue2);
        dialoguesList.Add(dialogue3);
    }

    private void Update() 
    {
        // spriteAnimator.HandleUpdate();
        if (state == NPCState.Idle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer > timeBetweenPattern)
            {
                idleTimer = 0f;
                if (movementPattern.Count > 0)
                    StartCoroutine(Walk());
            }
        }

        character.HandleUpdate();
        
    }

    IEnumerator Walk()
    {
        state = NPCState.Walking;

        var oldPos = transform.position;

        yield return character.Move(movementPattern[currentPattern]);

        if (transform.position != oldPos)
            currentPattern = (currentPattern + 1) % movementPattern.Count;

        state = NPCState.Idle;
    }

    public void Interact(Transform initiator) {
        if (state == NPCState.Idle && gameObject.CompareTag("Untagged"))
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue0, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Newspaper Boy"))
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue0, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
                GameController.Instance.state = GameState.Newspaper;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Spy") && DayTracker.Instance.Day == 0)
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue0, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        } else if (state == NPCState.Idle && gameObject.CompareTag("Spy") && DayTracker.Instance.Day == 1)
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue1, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Spy") && DayTracker.Instance.Day == 2)
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue2, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Spy") && DayTracker.Instance.Day == 3)
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue3, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Scientist"))
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialoguesList[DayTracker.Instance.Day], () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("Grunt"))
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue0, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
        else if (state == NPCState.Idle && gameObject.CompareTag("CoffeeLady"))
        {
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            var dialogueOption = 0;
            if (DayTracker.Instance.Day == 1)
                dialogueOption = 0;
            else if (DayTracker.Instance.Day == 0)
                dialogueOption = 2;
            else
                dialogueOption = 1;

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialoguesList[dialogueOption], () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
        }
    }
}

public enum NPCState { Idle, Walking, Dialogue }