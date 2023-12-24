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
        _attackSpeedField.text = "�������� ����� : " + attack.AttackTime.ToString();
        _damageField.text = "���� : " + attack.Damage.ToString();
        _maxDistanceField.text = "������ ����� : " + attack.Distance.ToString();
        _rotationSpeedField.text = "�������� ����� ��������� : " + PlayerCamera.Singleton.RotationSpeed.ToString();
    }
}

