using UnityEngine;

public class SoundIntensityIncreaser : MonoBehaviour
{
    private AudioSource _signalizationSound;

    private float _duration;
    private float _runningTime;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _duration = 3;
        _signalizationSound.Play();
    }

    public void Update()
    {
        IncreaseVolume();
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
