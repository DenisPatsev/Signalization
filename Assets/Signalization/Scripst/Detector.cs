using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Detector : MonoBehaviour
{
    private AudioSource _signalizationSound;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("����� �����");
            gameObject.GetComponent<VolumeChanger>().ResetRunningTime();
            gameObject.GetComponent<VolumeChanger>().SetInvasionIndicator(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("����� �����");
            gameObject.GetComponent<VolumeChanger>().ResetRunningTime();
            gameObject.GetComponent<VolumeChanger>().SetCurrentVolume(_signalizationSound.volume);
            gameObject.GetComponent<VolumeChanger>().SetInvasionIndicator(false);
        }
    }
}


