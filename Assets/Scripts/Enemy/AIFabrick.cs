using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFabrick : MonoBehaviour
{
    public Action<int> RenderUI;
    [SerializeField] private AIMovement _enemy;
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private float _ping;
    private readonly Timer _timer = new();
    private int _moneyForKill = 10;
    private float _currentSpeed = 2;
    private float _currentHealth = 10;
    private int _indexer = 20;

    public void StartGame()
    {
        _timer.StartTimer();
        _timer.Tick += (value) => RenderUI.Invoke(value);
        StartCoroutine(Spawner());
        PlayerCamera.Singleton.OnDie += ClearZone;
    }

    private IEnumerator Spawner()
    {
        while (PlayerCamera.Singleton.Alive)
        {
            UpdateValues();
            yield return new WaitForSeconds(_ping);
            if (!PlayerCamera.Singleton.Alive) yield break;
            var enemy = Instantiate(_enemy, _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count - 1)].transform.position, Quaternion.identity);
            enemy.Speed = _currentSpeed;
            enemy.Health = _currentHealth;
            enemy.GetComponent<AIHealth>().OnDestroy += () => PlayerCamera.Singleton.GetComponent<Wallet>().Add(_moneyForKill);
        }
    }

    public void SetDefaultValues()
    {
        _moneyForKill = 10;
        _currentSpeed = 2;
        _currentHealth = 10;
        _indexer = 20;
    }

    public void UpdateValues()
    {
        if (_timer.Time > _indexer)
        {
            _currentHealth += _currentHealth / 100 * 10;
            _currentSpeed += _currentSpeed / 100 * 10;
            _ping -= _ping / 100 * 10;
            _moneyForKill += 10;
            _indexer += 20;
            ErrorController.ShowError("Осторожно, сложность повышена");
        }
    }

    private void ClearZone()
    {
        _timer.Stop();
        StopCoroutine(Spawner());
        foreach(var item in FindObjectsOfType<AIHealth>()) Destroy(item.gameObject);
        print("all destroyed");
        PlayerCamera.Singleton.OnDie -= ClearZone;
        SetDefaultValues();
    }
}
