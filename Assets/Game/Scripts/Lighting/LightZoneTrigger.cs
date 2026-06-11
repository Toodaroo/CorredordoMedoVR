using UnityEngine;

public class LightZoneTrigger : MonoBehaviour
{
    public Light[] lightsToEnable;
    public Light[] lightsToDisable;
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnlyOnce && hasTriggered)
            return;

        if (!other.CompareTag("Player"))
            return;

        hasTriggered = true;

        foreach (Light lightToEnable in lightsToEnable)
        {
            if (lightToEnable != null)
                lightToEnable.enabled = true;
        }

        foreach (Light lightToDisable in lightsToDisable)
        {
            if (lightToDisable != null)
                lightToDisable.enabled = false;
        }

        Debug.Log("Zona de luz ativada: " + gameObject.name);
    }
}