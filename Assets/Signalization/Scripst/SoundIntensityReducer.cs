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
        _duration = 3;
       _currentVolume = _signalizationSound.volume;
    }

    public void Update()
    {
        ReduceVolume();
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
