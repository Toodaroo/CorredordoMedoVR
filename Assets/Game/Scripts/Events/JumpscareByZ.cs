using System.Collections;
using UnityEngine;

public class JumpscareByZ : MonoBehaviour
{
    [Header("Quando ativar")]
    public float triggerZ = 35f;

    [Header("Objeto visual do jumpscare")]
    public GameObject jumpscareObject;

    [Header("Som do jumpscare")]
    public AudioSource jumpscareAudio;

    [Header("Overlay escuro no momento do susto")]
    public DarkOverlayController darkOverlay;

    [Header("Tempo reserva caso não tenha áudio")]
    public float fallbackVisibleDuration = 1.2f;

    [Header("Controle")]
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;
    private VRAnalogMove analogMove;

    private void Awake()
    {
        analogMove = GetComponent<VRAnalogMove>();

        if (jumpscareObject == null)
        {
            Transform foundJumpscare = transform.Find("Main Camera/Jumpscare_Z35");

            if (foundJumpscare != null)
                jumpscareObject = foundJumpscare.gameObject;
        }

        if (jumpscareAudio == null && jumpscareObject != null)
        {
            jumpscareAudio = jumpscareObject.GetComponentInChildren<AudioSource>(true);
        }

        if (darkOverlay == null)
        {
            darkOverlay = GetComponentInChildren<DarkOverlayController>(true);
        }

        if (jumpscareObject != null)
            jumpscareObject.SetActive(false);
    }

    private void Update()
    {
        if (triggerOnlyOnce && hasTriggered)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasTriggered = true;
            StartCoroutine(JumpscareRoutine());
        }
    }

    private IEnumerator JumpscareRoutine()
    {
        Debug.Log("JUMPSCARE ATIVADO NO Z: " + triggerZ);

        // Para o movimento do jogador
        if (analogMove != null)
            analogMove.StopMovement();

        // Ativa o Dark Overlay NO MESMO MOMENTO DO SUSTO
        if (darkOverlay != null)
        {
            darkOverlay.FadeToDark();
            Debug.Log("DARK OVERLAY ATIVADO JUNTO COM O JUMPSCARE.");
        }
        else
        {
            Debug.LogWarning("JumpscareByZ: Dark Overlay não configurado.");
        }

        // Mostra o jumpscare
        if (jumpscareObject != null)
            jumpscareObject.SetActive(true);
        else
            Debug.LogWarning("JumpscareByZ: Jumpscare Object não configurado.");

        // Toca o som
        if (jumpscareAudio != null && jumpscareAudio.clip != null)
        {
            jumpscareAudio.loop = false;
            jumpscareAudio.Play();

            yield return new WaitWhile(() => jumpscareAudio != null && jumpscareAudio.isPlaying);
        }
        else
        {
            Debug.LogWarning("JumpscareByZ: áudio não configurado. Usando tempo reserva.");
            yield return new WaitForSeconds(fallbackVisibleDuration);
        }

        // Some com o jumpscare depois do áudio/tempo
        if (jumpscareObject != null)
            jumpscareObject.SetActive(false);

        Debug.Log("JUMPSCARE FINALIZADO.");
    }
}