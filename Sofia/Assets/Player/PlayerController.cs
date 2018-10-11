using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public List<Behaviour> LocalPlayerBehaviors;
    public GameObject CameraGameObject;

    public bool Spectral { get; private set; }
    public bool Dev_IsLocalPlayer = true;
    public bool CanInteract { get; private set; }

    private readonly float interactRangeInMeters = 1.5f;
    private LayerMask interactableLayerMask;
    private Camera camReference;

    void Start()
    {
        if (IsLocalPlayer())
        {
            GlobalManager.instance.RegisterLocalPlayer(this);
            LocalPlayerBehaviors.ForEach(b => b.enabled = true);
            CameraGameObject.SetActive(true);
            camReference = Camera.main;
            interactableLayerMask = LayerMask.GetMask("Interactable");
        }
    }

    void Update()
    {
        Dev_HandleSpectralToggle();
        HandleObjectInteraction();
    }

    private void HandleObjectInteraction()
    {
        CanInteract = false;
        Vector3 rayOrigin = camReference.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camReference.transform.forward, out hit, interactRangeInMeters, interactableLayerMask))
        {
            var interactable = hit.transform.GetComponent<Interactable>();

            if (interactable != null)
            {
                CanInteract = true;

                if (Input.GetKeyUp(KeyCode.E))
                    interactable.OnInteract();
            }
            else
                Debug.LogError("Gameobject was in layer mask Interactable, but there was no Interactable component on the target.");
        }
    }

    private bool IsLocalPlayer()
    {
        return isLocalPlayer;
    }

    //Only used for development.
    private void Dev_HandleSpectralToggle()
    {
        if (!IsLocalPlayer())
            return;

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Spectral)
            {
                Spectral = false;
            }
            else
            {
                Spectral = true;
            }
        }
    }
}
