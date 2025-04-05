using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action Completed;

    private Coroutine _coroutine;

    private float _secondsTotal;
    private float _secondsLeft;

    public void Setup(float seconds)
    {
        _secondsTotal = seconds;
    }

    public void Reset()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void Restart()
    {
        Reset();

        _secondsLeft = _secondsTotal;
        _coroutine = StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        while (_secondsLeft > 0)
        {
            _secondsLeft -= Time.deltaTime;

            yield return null;
        }

        Completed?.Invoke();
    }
}
