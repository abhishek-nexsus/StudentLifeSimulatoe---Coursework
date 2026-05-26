using UnityEngine;

public class EatInteraction : MonoBehaviour
{
    bool playerInside = false;
    PlayerInteractionAnimator playerAnimator;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if(playerAnimator != null)
            {
                playerAnimator.TriggerInteraction("Eat", 2f);
            }

            GameManager.instance.Eat();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
            playerAnimator = other.GetComponent<PlayerInteractionAnimator>();

            GameUIManager.instance.ShowMessage("Press E To Eat");
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