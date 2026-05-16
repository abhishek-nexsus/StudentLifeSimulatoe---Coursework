using UnityEngine;

public class SleepInteraction : MonoBehaviour
{
    bool playerInside = false;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.Sleep();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;

            GameUIManager.instance.ShowMessage("Press E To Sleep");
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