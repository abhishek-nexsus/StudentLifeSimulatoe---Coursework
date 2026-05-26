using UnityEngine;

public class SleepInteraction : MonoBehaviour
{
    bool playerInside = false;
    PlayerInteractionAnimator playerAnimator;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if(playerAnimator != null)
            {
                playerAnimator.TriggerInteraction("Sleep", 3f);
            }

            GameManager.instance.Sleep();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
            playerAnimator = other.GetComponent<PlayerInteractionAnimator>();

            GameUIManager.instance.ShowMessage("Press E To Sleep");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;
            playerAnimator = null;

            GameUIManager.instance.HideMessage();
        }
    }
}