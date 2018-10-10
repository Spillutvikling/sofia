using System;

internal interface IInteractable
{
    void SetInteractAction(Action interactAction);
    void OnInteract();
}