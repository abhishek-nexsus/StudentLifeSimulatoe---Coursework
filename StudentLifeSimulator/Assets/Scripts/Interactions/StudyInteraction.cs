using UnityEngine;

public class StudyInteraction : MonoBehaviour
{
    bool playerInside = false;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.Study();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;

            GameUIManager.instance.ShowMessage("Press E To Study");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;

            GameUIManager.instance.HideMessage();
        }
    }
}