using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 2.0f;
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 2.0f;
    private float nextFlickerTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }

        ScheduleNextFlicker();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFlickerTime)
        {
            // Randomize the light intensity
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Schedule the next flicker
            ScheduleNextFlicker();
        }
    }

    private void ScheduleNextFlicker()
    {
        // Randomize the time until the next flicker
        nextFlickerTime = Time.time + Random.Range(minFlickerTime, maxFlickerTime);
    }
}
