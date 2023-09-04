using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] float _duration;

    private AudioSource _signalizationSound;

    private float _runningTime;
    private float _currentVolume;
    private bool _isEntered;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _signalizationSound.Play();
    }

    private void Update()
    {
        if (_isEntered == false)
        {
            ReduceVolume();
        }
        else
        {
            IncreaseVolume();
        }
    }

    public void SetInvasionIndicator(bool isEntered)
    {
        _isEntered = isEntered;
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
}
