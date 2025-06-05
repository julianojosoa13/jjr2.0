using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact() {
        Debug.Log("Base Class Interact");
    }

    public virtual void ActivateVisual() {
        Debug.Log("Base Class Activate Visual");
    }

    public virtual void DeactivateVisual() {
        Debug.Log("Base Class Deactivate visual");
    }
}
