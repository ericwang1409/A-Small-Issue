using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// realnpc_0 (purple shirt guy) controller

public class realnpc_0controller : MonoBehaviour, Interactable
{
    // realnpc_0 displays its dialogue when interacted with
    [SerializeField] Dialogue dialogue;
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
        if (state == NPCState.Idle)
            state = NPCState.Dialogue;
            character.LookTowards(initiator.position);

            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue, () => {
                idleTimer = 0f;
                state = NPCState.Idle;
            }));
    }
}

public enum NPCState { Idle, Walking, Dialogue }