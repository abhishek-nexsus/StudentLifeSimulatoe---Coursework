using UnityEngine;

public class StudyInteraction : MonoBehaviour
{
    bool playerInside = false;
    PlayerInteractionAnimator playerAnimator;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if(playerAnimator != null)
            {
                playerAnimator.TriggerInteraction("Study", 2f);
            }

            GameManager.instance.Study();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
            playerAnimator = other.GetComponent<PlayerInteractionAnimator>();

            GameUIManager.instance.ShowMessage("Press E To Study");
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