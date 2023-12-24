using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<int> OnValueChanged;
    private int _money;

    private void Start() =>
        OnValueChanged?.Invoke(_money);
    
    public bool Spend(int value)
    {
        if (_money - value <= -1) return false;
        _money -= value;
        OnValueChanged?.Invoke(_money);
        return true;
    }

    public void Add(int value)
    {
        _money += value;
        OnValueChanged?.Invoke(_money);
    }
}
