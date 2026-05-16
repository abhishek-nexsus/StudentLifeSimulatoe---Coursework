using UnityEngine;

public class GamingInteraction : MonoBehaviour
{
    bool playerInside = false;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.PlayGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;

            GameUIManager.instance.ShowMessage("Press E To Play Games");
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