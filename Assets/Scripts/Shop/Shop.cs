using System;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Action OnBuy;
    [SerializeField] private TextMeshProUGUI _coolingField, _damageField, _rotationField, _distnaceField;
    private readonly int _mainCost = 100;
    private int _coolingDownCost, _damageCost, _rotationSpeedCost, _distanceCost;

    private void Start()
    {
        _coolingDownCost = _mainCost;
        _damageCost = _mainCost;
        _rotationSpeedCost = _mainCost;
        _distanceCost = _mainCost;
        SetFieldsValue();
        OnBuy?.Invoke();
    }

    public void UpCoolingDown()
    {
        if(!CheckCost(ref _coolingDownCost)) return;
        PlayerCamera.Singleton.GetComponent<PlayerAttack>().UpCoolingDown();
    }

    public void UpDamage()
    {
        if (!CheckCost(ref _damageCost)) return;
        PlayerCamera.Singleton.GetComponent<PlayerAttack>().UpDamage();
    }

    public void UpRotationSpeed()
    {
        if (!CheckCost(ref _rotationSpeedCost)) return;
        PlayerCamera.Singleton.UpRotateSpeed();
    }

    public void UpDistance()
    {
        if (!CheckCost(ref _distanceCost)) return;
        PlayerCamera.Singleton.GetComponent<PlayerAttack>().UpDistance(); 
    }

    private bool CheckCost(ref int cost)
    {
        if (PlayerCamera.Singleton.GetComponent<Wallet>().Spend(cost))
        {
            cost += cost / 2;
            SetFieldsValue();
            OnBuy?.Invoke();
            return true;
        }
        ErrorController.ShowError("Не достаточно средств");
        return false;
    }

    private void SetFieldsValue()
    {
        _coolingField.text = _coolingDownCost.ToString();
        _damageField.text = _damageCost.ToString();
        _rotationField.text = _rotationSpeedCost.ToString();
        _distnaceField.text = _distanceCost.ToString();
    }
}
