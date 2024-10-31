using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinNumber;
    int _startCoins = 0;

    public int _currentCoins;


    private void Start()
    {
        _coinNumber.text = $"Gold : {_startCoins.ToString()}";
    }

    public void UpCointAmount()
    {
        _currentCoins++;
        _coinNumber.text = $"Gold : {_currentCoins.ToString()}";
    }
}
