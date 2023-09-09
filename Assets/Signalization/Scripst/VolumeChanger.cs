using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] float _duration;

    private AudioSource _signalizationSound;

    private float _runningTime;
    private float _currentVolume;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _signalizationSound.Play();
    }

    public void ResetRunningTime()
    {
        _runningTime = 0;
    }

    public void SetCurrentVolume()
    {
        _currentVolume = _signalizationSound.volume;
    }

    public void StartIncreasing()
    {
        StartCoroutine(IncreaseVolume());
    }

    public void StartReducing()
    {
        StartCoroutine(ReduceVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        var waitingTime = new WaitForEndOfFrame();

        while (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(0, 1, normalizedTime);
            yield return waitingTime;
        }

        StopCoroutine(IncreaseVolume());
    }

    private IEnumerator ReduceVolume()
    {
        var waitingTime = new WaitForEndOfFrame();

        while (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(_currentVolume, 0, normalizedTime);
            yield return waitingTime;
        }

        StopCoroutine(ReduceVolume());
    }
}
