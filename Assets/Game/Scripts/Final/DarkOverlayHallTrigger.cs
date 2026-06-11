using UnityEngine;

public class DarkOverlayHallTrigger : MonoBehaviour
{
    public DarkOverlayController darkOverlay;
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entrou no Dark_Overlay_Hall: " + other.name);

        if (triggerOnlyOnce && hasTriggered)
            return;

        if (!other.CompareTag("Player"))
        {
            Debug.LogWarning("Entrou no trigger, mas NÃO tem tag Player: " + other.name);
            return;
        }

        hasTriggered = true;

        Debug.Log("PLAYER ENTROU NO TRIGGER. ESCURECENDO TELA.");

        if (darkOverlay != null)
        {
            darkOverlay.FadeToDark();
        }
        else
        {
            Debug.LogError("Dark Overlay não foi colocado no campo do trigger.");
        }
    }
}