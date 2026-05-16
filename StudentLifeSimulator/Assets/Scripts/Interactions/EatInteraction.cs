using UnityEngine;

public class EatInteraction : MonoBehaviour
{
    bool playerInside = false;

    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.Eat();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;

            GameUIManager.instance.ShowMessage("Press E To Eat");
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