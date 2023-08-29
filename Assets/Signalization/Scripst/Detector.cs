using UnityEngine;

public class Detector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject.GetComponent<SoundIntensityReducer>());
            gameObject.AddComponent<SoundIntensityIncreaser>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject.GetComponent<SoundIntensityIncreaser>());
            gameObject.AddComponent<SoundIntensityReducer>();
        }
    }
}


