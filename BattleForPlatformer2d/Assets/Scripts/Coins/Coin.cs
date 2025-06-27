using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _price;
    public event Action<Coin> Matched;

    public int Price => _price;

    public void PickUp() 
    {
        Matched.Invoke(this);
    }
}
