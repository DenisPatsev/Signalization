using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Detector : MonoBehaviour
{
    private AudioSource _signalizationSound;
    private VolumeChanger _volumeChanger;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _volumeChanger = gameObject.GetComponent<VolumeChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _volumeChanger.ResetRunningTime();
            _volumeChanger.SetInvasionIndicator(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _volumeChanger.ResetRunningTime();
            _volumeChanger.SetCurrentVolume(_signalizationSound.volume);
            _volumeChanger.SetInvasionIndicator(false);
        }
    }
}


