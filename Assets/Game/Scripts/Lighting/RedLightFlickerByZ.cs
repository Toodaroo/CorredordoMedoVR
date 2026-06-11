using System.Collections;
using UnityEngine;

public class RedLightFlickerByZ : MonoBehaviour
{
    [Header("Quando ativar")]
    public float triggerZ = 22f;

    [Header("Luz real que vai ficar vermelha")]
    public Light targetLight;

    [Header("Objeto visual da lâmpada")]
    public Renderer lampRenderer;

    [Header("Cor da ativação")]
    public Color activatedColor = Color.red;

    [Header("Som opcional")]
    public AudioSource flickerAudio;

    [Header("Configuração da piscada")]
    public int flickerCount = 4;
    public float flickerInterval = 0.07f;

    [Header("Controle")]
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;
    private float originalIntensity;
    private Material lampMaterial;

    private void Start()
    {
        if (targetLight != null)
        {
            originalIntensity = targetLight.intensity;
        }

        if (lampRenderer != null)
        {
            lampMaterial = lampRenderer.material;
        }
    }

    private void Update()
    {
        if (triggerOnlyOnce && hasTriggered)
            return;

        if (transform.position.z >= triggerZ)
        {
            hasTriggered = true;
            StartCoroutine(ActivateRedFlicker());
        }
    }

    private IEnumerator ActivateRedFlicker()
    {
        if (targetLight == null)
            yield break;

        // Muda a luz real para vermelho
        targetLight.color = activatedColor;
        targetLight.enabled = true;

        // Muda a lâmpada visual para vermelho
        SetLampMaterialColor(activatedColor);

        if (flickerAudio != null)
        {
            flickerAudio.Play();
        }

        for (int i = 0; i < flickerCount; i++)
        {
            targetLight.intensity = 0f;
            yield return new WaitForSeconds(flickerInterval);

            targetLight.intensity = originalIntensity;
            yield return new WaitForSeconds(flickerInterval);
        }

        // Mantém a luz vermelha depois da falha
        targetLight.intensity = originalIntensity;
        targetLight.color = activatedColor;
        SetLampMaterialColor(activatedColor);

        Debug.Log("Light_03 mudou para vermelho e piscou no Z: " + triggerZ);
    }

    private void SetLampMaterialColor(Color color)
    {
        if (lampMaterial == null)
            return;

        if (lampMaterial.HasProperty("_BaseColor"))
        {
            lampMaterial.SetColor("_BaseColor", color);
        }

        if (lampMaterial.HasProperty("_Color"))
        {
            lampMaterial.SetColor("_Color", color);
        }
    }
}