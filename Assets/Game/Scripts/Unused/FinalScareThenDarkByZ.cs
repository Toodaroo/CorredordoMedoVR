using System.Collections;
using UnityEngine;

public class FinalScareThenDarkByZ : MonoBehaviour
{
    [Header("Quando ativar o susto")]
    public float triggerZ = 35f;

    [Header("Som do susto principal")]
    public AudioSource finalScareAudio;

    [Header("Overlay escuro")]
    public DarkOverlayController darkOverlay;

    [Header("Delay depois do susto para escurecer")]
    public float delayBeforeDark = 0.45f;

    [Header("Controle")]
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;

    private void Update()
    {
        if (triggerOnlyOnce && hasTriggered)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasTriggered = true;
            StartCoroutine(FinalRoutine());
        }
    }

    private IEnumerator FinalRoutine()
    {
        Debug.Log("SUSTO PRINCIPAL ATIVADO NO Z: " + triggerZ);

        if (finalScareAudio != null)
            finalScareAudio.Play();

        yield return new WaitForSeconds(delayBeforeDark);

        if (darkOverlay != null)
        {
            darkOverlay.FadeToDark();
            Debug.Log("DARK OVERLAY ATIVADO DEPOIS DO SUSTO.");
        }
        else
        {
            Debug.LogWarning("FinalScareThenDarkByZ: Dark Overlay não configurado.");
        }
    }
}