using System.Collections;
using UnityEngine;

public class BoxTipByZ : MonoBehaviour
{
    [Header("Quando ativar")]
    public float triggerZ = 14f;

    [Header("Objeto que vai tombar")]
    public Transform boxTransform;

    [Header("Som do impacto")]
    public AudioSource impactAudio;

    [Header("Configuração do tombo")]
    public Vector3 tipRotationOffset = new Vector3(0f, 0f, 90f);
    public float tipDuration = 0.45f;
    public float soundDelay = 0.25f;

    private bool hasTriggered = false;

    private void Update()
    {
        if (hasTriggered)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasTriggered = true;
            StartCoroutine(TipBoxRoutine());
        }
    }

    private IEnumerator TipBoxRoutine()
    {
        if (boxTransform == null)
        {
            Debug.LogWarning("BoxTipByZ: Box Transform não configurado.");
            yield break;
        }

        Quaternion startRotation = boxTransform.localRotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(tipRotationOffset);

        float timer = 0f;
        bool soundPlayed = false;

        while (timer < tipDuration)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / tipDuration);

            // Movimento mais natural: começa suave e termina suave
            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            boxTransform.localRotation = Quaternion.Lerp(startRotation, targetRotation, smoothT);

            if (!soundPlayed && timer >= soundDelay)
            {
                soundPlayed = true;

                if (impactAudio != null)
                    impactAudio.Play();
            }

            yield return null;
        }

        boxTransform.localRotation = targetRotation;

        if (!soundPlayed && impactAudio != null)
            impactAudio.Play();

        Debug.Log("Caixa tombou no Z: " + triggerZ);
    }
}