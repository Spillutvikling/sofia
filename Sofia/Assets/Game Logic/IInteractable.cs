using System;

internal interface IInteractable
{
    void SetInteractAction(Action interactAction, string name);
    void OnInteract();
}