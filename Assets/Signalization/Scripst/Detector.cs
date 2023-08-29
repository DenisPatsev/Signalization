using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Detector : MonoBehaviour
{
    [SerializeField] float _duration;
    private AudioSource _signalizationSound;

    private float _runningTime;

    private void Start()
    {
        _signalizationSound = GetComponent<AudioSource>();
        _signalizationSound.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        Destroy(gameObject.GetComponent<SoundIntensityReducer>());

        if (other.TryGetComponent<Player>(out Player player))
        {
            _runningTime += Time.deltaTime;
            float normalizedTime = _runningTime / _duration;

            _signalizationSound.volume = Mathf.MoveTowards(0, 1, normalizedTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            gameObject.AddComponent<SoundIntensityReducer>().SetDuration(_duration);
            _runningTime = 0;
        }
    }
}


