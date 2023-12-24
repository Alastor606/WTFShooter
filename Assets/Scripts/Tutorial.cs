using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tutorField;
    [SerializeField] private string[] _info;
    [SerializeField] private Canvas _tutor;
    public bool IsCompleting = true;

    private IEnumerator Start()
    {
        _tutor.enabled = true;
        for(int i = 0; i < _info.Length; i++)
        {
            _tutorField.text = _info[i];
            yield return new WaitForSeconds(3);
        }
        _tutor.enabled = false;
        IsCompleting = false;
    }

    public void Skip()
    {
        StopCoroutine(nameof(Start));
        _tutor.enabled = false;
        IsCompleting = false;
    }
       
}
