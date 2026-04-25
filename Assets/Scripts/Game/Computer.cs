using UnityEngine;
using UnityEngine.InputSystem;

public class Computer : MonoBehaviour
{
    public GameObject promptPanel;   // UI panel to show
    private bool playerInRange = false;

    void Start()
    {
        promptPanel.SetActive(false);

    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (playerInRange)
        {
            promptPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            promptPanel.SetActive(true);
            PauseController.SetPause(promptPanel.activeSelf);
   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            promptPanel.SetActive(false);
        }
    }
}
