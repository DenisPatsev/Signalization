using UnityEngine;

[RequireComponent(typeof(Light))]

public class PingPongLightMode : MonoBehaviour
{
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        _light.intensity = Mathf.PingPong(Time.time * 2, 1);
    }
}
