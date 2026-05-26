using System.Collections;
using UnityEngine;

public class PlayerInteractionAnimator : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public float defaultInteractionDuration = 1.5f;

    public bool IsInteracting { get; private set; }

    public void TriggerInteraction(string triggerName, float duration = -1f)
    {
        if (IsInteracting)
            return;

        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }

        if (characterController == null)
            characterController = GetComponent<CharacterController>();

        if (characterController != null)
            characterController.enabled = false;

        IsInteracting = true;
        StartCoroutine(EndInteractionAfter(duration > 0f ? duration : defaultInteractionDuration));
    }

    IEnumerator EndInteractionAfter(float duration)
    {
        yield return new WaitForSeconds(duration);

        if (characterController != null)
            characterController.enabled = true;

        IsInteracting = false;
    }
}
