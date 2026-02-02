using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.Universal;

public class SvjetloTreperi : MonoBehaviour
{
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.1f;

    Light2D light2D;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        light2D.intensity = Mathf.Lerp(
            light2D.intensity,
            Random.Range(minIntensity, maxIntensity),
            flickerSpeed
        );
    }
}
