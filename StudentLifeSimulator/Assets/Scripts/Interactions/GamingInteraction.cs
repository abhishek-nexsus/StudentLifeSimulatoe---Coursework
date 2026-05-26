using UnityEngine;

public class GamingInteraction : MonoBehaviour
{
    bool playerInside = false;
    PlayerInteractionAnimator playerAnimator;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if(playerAnimator != null)
            {
                playerAnimator.TriggerInteraction("Gaming", 2f);
            }

            GameManager.instance.PlayGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
            playerAnimator = other.GetComponent<PlayerInteractionAnimator>();

            GameUIManager.instance.ShowMessage("Press E To Play Games");
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