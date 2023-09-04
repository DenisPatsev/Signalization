using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] float _duration;

    private AudioSource _signalizationSound;

    private float _runningTime;
    private float _currentVolume;
    private bool _isEntered;
    private float _minimalVolume;
    private float _maximalVolume;
    private float _correctingVolumeStep;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _signalizationSound.Play();
        _minimalVolume = 0;
        _maximalVolume = 1;
        _correctingVolumeStep = 0.01f;
    }

    private void Update()
    {
        if (_signalizationSound.volume > _minimalVolume && _signalizationSound.volume < _maximalVolume)
        {
            StartCoroutine(ChangePlayCondition());
        }
        else
        {
            StopCoroutine(ChangePlayCondition());
        }
    }

    public void SetInvasionIndicator(bool isEntered)
    {
        _isEntered = isEntered;

        if (_isEntered == true)
        {
            _signalizationSound.volume += _correctingVolumeStep;
        }
        else
        {
            _signalizationSound.volume -= _correctingVolumeStep;
        }
    }

    public void ResetRunningTime()
    {
        _runningTime = 0;
    }

    public void SetCurrentVolume(float currentVolume)
    {
        _currentVolume = currentVolume;
    }

    private void ReduceVolume()
    {
        if (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(_currentVolume, 0, normalizedTime);
        }
    }

    private void IncreaseVolume()
    {
        if (_runningTime < _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(0, 1, normalizedTime);
        }
    }

    private IEnumerator ChangePlayCondition()
    {
        if (_isEntered == false)
        {
            ReduceVolume();
        }
        else
        {
            IncreaseVolume();
        }

        yield return null;
    }
}
