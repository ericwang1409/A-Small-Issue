using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeReference]
    [SerializeField] List<CutsceneAction> actions;

    public IEnumerator Play()
    {
        GameController.Instance.StartCutsceneState();

        foreach (var action in actions)
        {
            yield return action.Play();
        }

        GameController.Instance.StartFreeRoamState();
    } 

    public void AddAction(CutsceneAction action)
    {
        action.Name = action.GetType().ToString();
        actions.Add(action);
    }
}
