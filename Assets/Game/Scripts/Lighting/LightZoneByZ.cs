using UnityEngine;

public class LightZoneByZ : MonoBehaviour
{
    [Header("Luzes do corredor")]
    public Light light01;
    public Light light02;
    public Light light03;
    public Light light04;

    [Header("Pontos Z onde troca a luz")]
    public float zone02StartZ = 10f;
    public float zone03StartZ = 20f;
    public float zone04StartZ = 30f;

    private int currentZone = -1;

    private void Start()
    {
        UpdateLightZone(true);
    }

    private void Update()
    {
        UpdateLightZone(false);
    }

    private void UpdateLightZone(bool forceUpdate)
    {
        float playerZ = transform.position.z;

        int newZone;

        if (playerZ >= zone04StartZ)
        {
            newZone = 4;
        }
        else if (playerZ >= zone03StartZ)
        {
            newZone = 3;
        }
        else if (playerZ >= zone02StartZ)
        {
            newZone = 2;
        }
        else
        {
            newZone = 1;
        }

        if (!forceUpdate && newZone == currentZone)
            return;

        currentZone = newZone;
        ApplyZone(currentZone);

        Debug.Log("Zona de luz atual: " + currentZone + " | Player Z: " + playerZ);
    }

    private void ApplyZone(int zone)
    {
        SetLight(light01, zone == 1);
        SetLight(light02, zone == 2);
        SetLight(light03, zone == 3);
        SetLight(light04, zone == 4);
    }

    private void SetLight(Light targetLight, bool active)
    {
        if (targetLight == null)
            return;

        targetLight.gameObject.SetActive(true);
        targetLight.enabled = active;
    }
}