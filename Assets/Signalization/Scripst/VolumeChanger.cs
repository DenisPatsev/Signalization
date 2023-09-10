using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private float _duration;

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

    public void StartAlteration(float endValue)
    {
        StartCoroutine(AlterVolume(endValue));
    }

    public IEnumerator AlterVolume(float endValue)
    {
        var waitingTime = new WaitForEndOfFrame();

        while (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(_currentVolume, endValue, normalizedTime);
            yield return waitingTime;
        }
    }
}
