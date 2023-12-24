using TMPro;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyField;
    [SerializeField] private Wallet wallet;
    private void Start() =>
        wallet.OnValueChanged += Render;
    private void OnValidate() =>
        wallet ??= GetComponent<Wallet>();
    private void Render(int value) =>
        _moneyField.text = value.ToString();

}
