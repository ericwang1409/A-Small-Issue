using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS ISN'T ACTUALLY JUST FOR THE PLAYER SIGN, I WOULD RATHER JUST NOT
// BREAK THIS MORE AND IT WORKS FOR NOW SO BE IT

public class PlayerHouseSign : MonoBehaviour, Interactable
{
    [SerializeField] private Dialogue playerHouseDialogue; // Assign this in the Inspector

    public void Interact(Transform initiator)
    {
        StartCoroutine(InteractCoroutine(initiator));
    }

    private IEnumerator InteractCoroutine(Transform initiator)
    {
        // Ensure that playerHouseDialogue is assigned
        if (playerHouseDialogue == null)
        {
            Debug.LogError("PlayerHouseDialogue is not assigned in the Inspector");
            yield break; // Stop the coroutine if there's no dialogue assigned
        }

        // Use the preassigned dialogue
        yield return StartCoroutine(DialogueManager.Instance.ShowDialogue(playerHouseDialogue));
    }
}
