using System;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public Action OnDestroy;
    public float Value = 10;

    public void TakeDamage(float damage)
    {
        Value -= damage;
        if (Value < 0)
        {
            OnDestroy?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
