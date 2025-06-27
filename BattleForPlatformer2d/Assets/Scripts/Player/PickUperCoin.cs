using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUperCoin : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
            _wallet.Replenishment(coin.Price);
        }
    }
}
