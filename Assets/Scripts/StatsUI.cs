using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private TextMeshProUGUI _attackSpeedField, _rotationSpeedField, _damageField, _maxDistanceField;

    private void Start()
    {
        _shop.OnBuy += Render;
    }

    private void Render()
    {
        var attack = PlayerCamera.Singleton.GetComponent<PlayerAttack>();
        _attackSpeedField.text = "Скорость атаки : " + attack.AttackTime.ToString();
        _damageField.text = "Урон : " + attack.Damage.ToString();
        _maxDistanceField.text = "Радиус атаки : " + attack.Distance.ToString();
        _rotationSpeedField.text = "Задержка перед поворотом : " + PlayerCamera.Singleton.RotationSpeed.ToString();
    }
}

