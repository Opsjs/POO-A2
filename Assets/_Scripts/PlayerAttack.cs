using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;

    public event Action OnStartAttack;

    Coroutine AttackRoutine { get; set; }

    private void Start()
    {
        _attack.action.started += StartAttack;
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        AttackRoutine = StartCoroutine(Attack());
        IEnumerator Attack()
        {
            OnStartAttack?.Invoke();
            while (true)
            {
                
                // Script attack

                yield return null;
            }
        }
    }
}
