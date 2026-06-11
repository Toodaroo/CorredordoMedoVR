using UnityEngine;

public class ScareSoundByZ : MonoBehaviour
{
    [Header("Quando ativar")]
    public float triggerZ = 7f;

    [Header("Áudio")]
    public AudioSource audioSource;

    [Header("Controle")]
    public bool playOnlyOnce = true;

    private bool hasPlayed = false;

    private void Update()
    {
        if (playOnlyOnce && hasPlayed)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasPlayed = true;

            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("Som ativado no Z: " + triggerZ);
            }
            else
            {
                Debug.LogWarning("ScareSoundByZ: AudioSource não configurado.");
            }
        }
    }
}