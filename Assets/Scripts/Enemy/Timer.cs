using System;
using System.Collections;
using UnityEngine;

public class Timer 
{
    public Action<int> Tick;
    public int Time { get ; private set; }
    private bool _canPlaying = false;
    public IEnumerator StartTimer()
    {
        Time = 0;
        _canPlaying = true;
        while (_canPlaying)
        {
            yield return new WaitForSeconds(1);
            Time++;
            Tick?.Invoke(Time);
        }
    }

    public void Stop() =>
        _canPlaying = false;
    
}
