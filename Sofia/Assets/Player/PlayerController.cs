using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Spectral { get; private set; }
    public bool Dev_IsLocalPlayer = true;

    void Start()
    {
        if (IsLocalPlayer())
        {
            GlobalManager.instance.RegisterLocalPlayer(this);
        }
    }

    void Update()
    {
        Dev_HandleSpectralToggle();
    }

    private bool IsLocalPlayer()
    {
        return Dev_IsLocalPlayer; // When networkBehaviour, return isLocalPlayer instead.
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
