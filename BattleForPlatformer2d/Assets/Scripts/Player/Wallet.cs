using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public void Replenishment(int accruedMoney) 
    {
        _money += accruedMoney;
    }
}
