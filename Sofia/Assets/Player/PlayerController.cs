using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public List<Behaviour> LocalPlayerBehaviors;
    public GameObject Camera;

    public bool Spectral { get; private set; }
    public bool Dev_IsLocalPlayer = true;

    void Start()
    {
        if (IsLocalPlayer())
        {
            GlobalManager.instance.RegisterLocalPlayer(this);
            LocalPlayerBehaviors.ForEach(b => b.enabled = true);
            Camera.SetActive(true);
        }
    }

    void Update()
    {
        Dev_HandleSpectralToggle();
    }

    private bool IsLocalPlayer()
    {
        return isLocalPlayer; // When networkBehaviour, return isLocalPlayer instead.
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
