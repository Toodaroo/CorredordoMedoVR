using System.Collections;
using UnityEngine;

public class ScareLightFlickerByZ : MonoBehaviour
{
    [Header("Quando ativar")]
    public float triggerZ = 4f;

    [Header("Luz que vai piscar")]
    public Light targetLight;

    [Header("Som da luz piscando")]
    public AudioSource flickerAudio;
    public bool playSoundAtStart = true;
    public bool fadeOutSound = true;
    public float audioFadeOutDuration = 1.2f;

    [Header("Configuração da piscada")]
    public int flickerCount = 6;
    public float flickerInterval = 0.08f;

    [Header("Controle")]
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;
    private float originalLightIntensity;
    private float originalAudioVolume;

    private void Start()
    {
        if (targetLight != null)
            originalLightIntensity = targetLight.intensity;

        if (flickerAudio != null)
            originalAudioVolume = flickerAudio.volume;
    }

    private void Update()
    {
        if (triggerOnlyOnce && hasTriggered)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasTriggered = true;
            StartCoroutine(FlickerRoutine());
        }
    }

    private IEnumerator FlickerRoutine()
    {
        if (targetLight == null)
            yield break;

        if (flickerAudio != null && playSoundAtStart)
        {
            flickerAudio.volume = originalAudioVolume;
            flickerAudio.Play();
        }

        targetLight.enabled = true;

        for (int i = 0; i < flickerCount; i++)
        {
            targetLight.intensity = 0f;
            yield return new WaitForSeconds(flickerInterval);

            targetLight.intensity = originalLightIntensity;
            yield return new WaitForSeconds(flickerInterval);
        }

        targetLight.intensity = originalLightIntensity;

        if (flickerAudio != null && fadeOutSound)
        {
            yield return StartCoroutine(FadeOutAudio());
        }

        Debug.Log("Susto de luz + som ativado na luz: " + targetLight.name);
    }

    private IEnumerator FadeOutAudio()
    {
        float startVolume = flickerAudio.volume;
        float timer = 0f;

        while (timer < audioFadeOutDuration)
        {
            timer += Time.deltaTime;
            float t = timer / audioFadeOutDuration;

            flickerAudio.volume = Mathf.Lerp(startVolume, 0f, t);

            yield return null;
        }

        flickerAudio.volume = 0f;
        flickerAudio.Stop();

        // Restaura o volume para caso você teste de novo ou reaproveite depois
        flickerAudio.volume = originalAudioVolume;
    }
}