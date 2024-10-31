using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField, Required] GoldUI _goldUI;
    [SerializeField, Tag] string _playerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            _goldUI.UpCointAmount();
        }
    }
}
