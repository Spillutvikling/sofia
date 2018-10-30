using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour, IInteractable
{
    private Action _interactAction;

    public void SetInteractAction(Action interactAction)
    {
        _interactAction = interactAction;
    }

    public void OnInteract()
    {
        if (_interactAction != null)
            _interactAction();
        else
            Debug.LogError("Interactable is missing an interaction action");
    }
}
