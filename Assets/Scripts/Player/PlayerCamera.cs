using System;
using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Action OnDie;
    [SerializeField] private Camera _cam;
    [SerializeField] private Tutorial _tutor;
    [SerializeField, Range(0, 1)] private float _cooldown;
    public static PlayerCamera Singleton { get; private set; }
    public float RotationSpeed { get { return _cooldown; } }
    private bool _onCooldown = false;
    public bool Alive { get; private set; } = true;

    private void Awake() =>
        Singleton = this;
    private void Start() =>
        _cam.transform.rotation = Quaternion.Euler(0,0,0);
    public void Right() =>
        _cam.transform.Rotate(0, 90, 0);
    public void Left() =>
        _cam.transform.Rotate(0, -90, 0);

    private void Update()
    {
        if (_onCooldown || _tutor.IsCompleting) return;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
            StartCoroutine(CoolingDown());
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
            StartCoroutine(CoolingDown());
        }
    }

    private IEnumerator CoolingDown()
    {
        _onCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _onCooldown = false;
    }

    public void UpRotateSpeed() =>
        _cooldown -= _cooldown / 100 * 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AIHealth _))
        {
            ErrorController.ShowError("Вы погибли...");
            Alive = false;
            OnDie?.Invoke();
        }
    }

    public void SetAlive() => Alive = true;
}
