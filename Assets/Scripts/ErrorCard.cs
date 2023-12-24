using TMPro;
using UnityEngine;
public class ErrorCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _errorTextField;
    public void Render(string message) =>
        _errorTextField.text = message;
}