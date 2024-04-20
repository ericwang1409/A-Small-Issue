using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 5:41 for the whole file video 40
    private Vector2 input;
    private Character character;
    const float offsetY = 0.3f;

    // something that talks to animator to make it go?
    private void Awake()
    {
        character = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMoveOver()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, offsetY), 0.2f, GameLayers.i.TriggerableLayers);

        foreach (var collider in colliders)
        {
            var triggable = collider.GetComponent<IPlayerTriggerable>();
            if (triggable != null)
            {
                character.Animator.IsMoving = false;
                triggable.OnPlayerTriggered(this);
                break;
            }
        }
    }

    // HandleUpdate is called once per frame IF game in FreeRoam...
    // based on GameController.cs
    public void HandleUpdate()
    {
        // If not already moving, get input
        if (!character.IsMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //No horizontal
            if (input.x != 0) input.y = 0;

            // Tells animator what's going on
            if (input != Vector2.zero) {
                StartCoroutine(character.Move(input, OnMoveOver));
            }
        }

        character.HandleUpdate();

        // Bool used to transititon between walking and idling animations
        
        // 'Z' key is used to interact with stuff, generally
        if (Input.GetKeyDown(KeyCode.Z)) {Interact();}
    }

    // To interact with something means to 'look at it' ...
    // (have it right in front of you) and press Z
    void Interact() {
        var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + facingDir;

        // Debug.DrawLine(transform.position, interactPos, Color.red, 0.5f);

        // If interactable, interact with the component
        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractablesLayer);
        if (collider != null) {
            collider.GetComponent<Interactable>()?.Interact(transform);
        }
    }
}
