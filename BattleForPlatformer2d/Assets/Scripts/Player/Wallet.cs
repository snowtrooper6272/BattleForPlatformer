using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public void IncreaseBalance(int accruedMoney) 
    {
        _money += accruedMoney;
    }
}
