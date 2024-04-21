using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
