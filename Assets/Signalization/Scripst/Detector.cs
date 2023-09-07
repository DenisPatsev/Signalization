using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Detector : MonoBehaviour
{
    private AudioSource _signalizationSound;
    private VolumeChanger _alarm;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _alarm = gameObject.GetComponent<VolumeChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _alarm.ResetRunningTime();
            _alarm.SetInvasionIndicator(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _alarm.ResetRunningTime();
            _alarm.SetCurrentVolume(_signalizationSound.volume);
            _alarm.SetInvasionIndicator(false);
        }
    }
}


