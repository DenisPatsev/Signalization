using UnityEngine;

[RequireComponent(typeof(Light))]

public class PingPongLightMode : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lenght;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        _light.intensity = Mathf.PingPong(Time.time * _speed, _lenght);
    }
}
