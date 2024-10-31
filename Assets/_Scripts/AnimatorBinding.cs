using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField, Required] Animator _animator;

    [SerializeField, Required] PlayerMove _move;
    [SerializeField, Required] PlayerAttack _attack;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] string _isAttackingTriggerParam;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _isWalkingBoolParam = "Walking";
    }


    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;

        _attack.OnStartAttack += _attack_OnStartAttack;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

    private void _attack_OnStartAttack()
    {
        _animator.SetTrigger(_isAttackingTriggerParam);
    }

}
