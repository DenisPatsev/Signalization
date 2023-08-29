using UnityEngine;

public class PingPongLightMode : MonoBehaviour
{
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        _light.intensity = Mathf.PingPong(Time.time * 2, 1);
    }
}
