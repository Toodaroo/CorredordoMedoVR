using System.Collections;
using UnityEngine;

public class AmbientSoundUntilZ : MonoBehaviour
{
    [Header("Som ambiente")]
    public AudioSource ambientAudio;

    [Header("Quando o som deve começar a morrer")]
    public float stopAtZ = 4f;

    [Header("Fade")]
    public float fadeOutDuration = 1.5f;

    [Header("Volume inicial")]
    public float startVolume = 0.25f;

    private bool hasStopped = false;

    private void Start()
    {
        if (ambientAudio != null)
        {
            ambientAudio.volume = startVolume;
            ambientAudio.loop = true;
            ambientAudio.Play();
        }
    }

    private void Update()
    {
        if (hasStopped)
            return;

        if (transform.position.z >= stopAtZ)
        {
            hasStopped = true;
            StartCoroutine(FadeOutAmbient());
        }
    }

    private IEnumerator FadeOutAmbient()
    {
        if (ambientAudio == null)
            yield break;

        float timer = 0f;
        float initialVolume = ambientAudio.volume;

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeOutDuration;

            ambientAudio.volume = Mathf.Lerp(initialVolume, 0f, t);

            yield return null;
        }

        ambientAudio.volume = 0f;
        ambientAudio.Stop();

        Debug.Log("Som ambiente parou no Z: " + stopAtZ);
    }
}