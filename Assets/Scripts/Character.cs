using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterAnimator animator;
    public float moveSpeed;
    public bool IsMoving {get; private set;}
    public float OffsetY {get; private set;} = 0.3f;

    private void Awake() 
    {
        animator = GetComponent<CharacterAnimator>();
        if (gameObject.tag == "Player") {
        SetPositionAndSnapToTile(transform.position); 
        }
    }

    public void SetPositionAndSnapToTile(Vector2 pos) {
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f + OffsetY;

        transform.position = pos;
    }

    public IEnumerator Move(Vector2 moveVec, Action OnMoveOver=null) 
    {
        animator.MoveX = Mathf.Clamp(moveVec.x, -1f, 1f);
        animator.MoveY = Mathf.Clamp(moveVec.y, -1f, 1f);

        // Sets target position to place you keystroked to
        var targetPos = transform.position;
        targetPos.x += moveVec.x;
        targetPos.y += moveVec.y;

        if (!IsPathClear(targetPos)) {
            yield break;
        }

        IsMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        IsMoving = false;
        OnMoveOver?.Invoke();
    }

    public void HandleUpdate()
    {
        animator.IsMoving = IsMoving;
    }

    private bool IsPathClear(Vector3 targetPos)
    {
        var diff  = targetPos - transform.position;
        var dir = diff.normalized;
  
        if (Physics2D.BoxCast(transform.position + dir, new Vector2(0.2f, 0.2f), 0f, dir, diff.magnitude - 1, GameLayers.i.SolidsLayer | GameLayers.i.InteractablesLayer | GameLayers.i.PlayerLayer) == true)
        {
            return false;
        }
            
        return true;
    }   

    private bool isWalkable(Vector3 targetPos) {
        if (Physics2D.OverlapCircle(targetPos, 0.15f, GameLayers.i.SolidsLayer | GameLayers.i.InteractablesLayer) != null) {
            return false;
        } else {
            return true; 
        }
    }

    public void LookTowards(Vector3 targetPos)
    {
        var xdiff = Mathf.Floor(targetPos.x) - Mathf.Floor(transform.position.x);
        var ydiff = Mathf.Floor(targetPos.y) - Mathf.Floor(transform.position.y);

        if (xdiff == 0 || ydiff == 0) {
            animator.MoveX = Mathf.Clamp(xdiff, -1f, 1f);
            animator.MoveY = Mathf.Clamp(ydiff, -1f, 1f);
        } else {
            Debug.LogError("Character can only look in straight lines");
        }
    }

    public CharacterAnimator Animator 
    {
        get => animator;
    }
}
