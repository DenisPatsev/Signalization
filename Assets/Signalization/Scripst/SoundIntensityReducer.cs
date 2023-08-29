using Unity.VisualScripting;
using UnityEngine;

public class SoundIntensityReducer : MonoBehaviour
{
    private AudioSource _signalizationSound;

    private float _duration;
    private float _runningTime;
    private float _currentVolume;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _currentVolume = _signalizationSound.volume;
    }

    public void Update()
    {
        ReduceVolume();
    }

    public void SetDuration(float value)
    {
        _duration = value;
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
}
