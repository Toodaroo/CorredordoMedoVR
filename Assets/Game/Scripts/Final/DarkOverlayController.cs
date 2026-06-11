using System.Collections;
using UnityEngine;

public class DarkOverlayController : MonoBehaviour
{
    [Header("Alpha em escala 0-255")]
    public int startAlpha = 40;
    public int targetAlpha = 255;

    [Header("Duração do escurecimento em segundos")]
    public float fadeDuration = 2.5f;

    private Renderer overlayRenderer;
    private Material overlayMaterial;
    private Coroutine fadeCoroutine;

    private void Awake()
    {
        overlayRenderer = GetComponent<Renderer>();

        if (overlayRenderer == null)
        {
            Debug.LogError("DarkOverlayController: nenhum Renderer encontrado.");
            return;
        }

        overlayMaterial = overlayRenderer.material;

        SetAlpha255(startAlpha);
    }

    public void FadeToDark()
    {
        if (overlayMaterial == null)
            return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeAlphaSmooth(startAlpha, targetAlpha, fadeDuration));
    }

    private IEnumerator FadeAlphaSmooth(int fromAlpha255, int toAlpha255, float duration)
    {
        duration = Mathf.Max(0.01f, duration);

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float t = timer / duration;

            // Deixa o fade mais cinematográfico, não linear seco
            t = Mathf.SmoothStep(0f, 1f, t);

            int currentAlpha = Mathf.RoundToInt(Mathf.Lerp(fromAlpha255, toAlpha255, t));

            SetAlpha255(currentAlpha);

            yield return null;
        }

        SetAlpha255(toAlpha255);
    }

    private void SetAlpha255(int alpha255)
    {
        alpha255 = Mathf.Clamp(alpha255, 0, 255);
        float alpha01 = alpha255 / 255f;

        if (overlayMaterial.HasProperty("_BaseColor"))
        {
            Color color = overlayMaterial.GetColor("_BaseColor");
            color.r = 0f;
            color.g = 0f;
            color.b = 0f;
            color.a = alpha01;
            overlayMaterial.SetColor("_BaseColor", color);
        }

        if (overlayMaterial.HasProperty("_Color"))
        {
            Color color = overlayMaterial.GetColor("_Color");
            color.r = 0f;
            color.g = 0f;
            color.b = 0f;
            color.a = alpha01;
            overlayMaterial.SetColor("_Color", color);
        }
    }
}