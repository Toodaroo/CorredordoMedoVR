using UnityEngine;
using UnityEngine.InputSystem;

public class GameStartMenu : MonoBehaviour
{
    [Header("Menu inicial")]
    public GameObject startMenuObject;

    [Header("Movimento do jogador")]
    public VRAnalogMove playerMovement;

    [Header("Controle")]
    public bool started = false;
    public bool allowKeyboardTest = true;

    private void Start()
    {
        if (startMenuObject != null)
            startMenuObject.SetActive(true);

        if (playerMovement != null)
            playerMovement.canMove = false;
    }

    private void Update()
    {
        if (started)
            return;

        bool pressedStart = false;

        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            pressedStart = true;

        if (allowKeyboardTest && Keyboard.current != null)
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
                pressedStart = true;
        }

        if (pressedStart)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        started = true;

        if (startMenuObject != null)
            startMenuObject.SetActive(false);

        if (playerMovement != null)
            playerMovement.canMove = true;

        Debug.Log("JOGO INICIADO PELO BOTAO A / ENTER.");
    }
}