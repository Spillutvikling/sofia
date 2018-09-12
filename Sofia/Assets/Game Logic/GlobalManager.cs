using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private PlayerController localPlayer;

    public static GlobalManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
        {
            Debug.LogError("Tried to create another instance of " + GetType() + ". Destroying.");
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void RegisterLocalPlayer(PlayerController player)
    {
        localPlayer = player;
    }

    public PlayerController GetLocalPlayer()
    {
        if(localPlayer == null)
        {
            Debug.LogWarning("GetLocalPlayer called while localPlayer is still null. Might be ok, maybe we wanna avoid it?");
        }

        return localPlayer;
    }
}
