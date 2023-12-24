using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<Canvas> _ui;

    public void Start()
    {
        PlayerCamera.Singleton.OnDie += On;
    }

    public void Off()
    {
        foreach (Canvas c in _ui) c.enabled = false; 
    }

    private void On()
    {
        foreach (var c in _ui) c.enabled = true;
    }
}
