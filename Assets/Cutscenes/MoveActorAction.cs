using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActorAction : CutsceneAction
{
    [SerializeField] Character character;  
    [SerializeField] List<Vector2> movePattern;

    public override IEnumerator Play()
    {
        foreach (var moveVec in movePattern) 
        {
            yield return character.Move(moveVec);
        }
    }
}
