using System;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public string debugName;

    private string _name;
    private Action _interactAction;

    public void SetInteractAction(Action interactAction, string name)
    {
        _interactAction = interactAction;
        _name = name;
    }

    public void OnInteract()
    {
        if (_interactAction != null)
            _interactAction();
        else
            Debug.LogError("Interactable is missing an interaction action");
    }
}
