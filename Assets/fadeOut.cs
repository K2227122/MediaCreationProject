using System.Collections;
using UnityEngine;

public class fadeOut : MonoBehaviour
{
    public Light pointLight;               // Assign the child Point Light
    public ParticleSystem particleSystem;  // Assign the child Particle System
    public float fadeDuration = 2f;        // How long the fade lasts

    private float initialLightIntensity;
    private ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        if (pointLight)
            initialLightIntensity = pointLight.intensity;

        if (particleSystem)
            emissionModule = particleSystem.emission;

       
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }


    IEnumerator FadeOut()
    {
        float time = 0;
        float initialEmissionRate = emissionModule.rateOverTime.constant;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float fadeFactor = 1 - (time / fadeDuration);

            // Fade the light intensity
            if (pointLight)
                pointLight.intensity = initialLightIntensity * fadeFactor;

            // Fade the particle system emission rate
            if (particleSystem)
                emissionModule.rateOverTime = initialEmissionRate * fadeFactor;

            yield return null;
        }

        // Ensure everything is fully off
        if (pointLight)
            pointLight.intensity = 0;

        if (particleSystem)
        {
            emissionModule.rateOverTime = 0;
            particleSystem.Stop();
        }

        gameObject.SetActive(false); // Disable the GameObject
    }
}
