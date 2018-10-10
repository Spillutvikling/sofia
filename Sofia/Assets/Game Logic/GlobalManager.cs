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

    /// <summary>
    /// Not guaranteed to be instantiated when called. 
    /// Maybe we need to add a warning here in the future and work out the order of how objects are instantiated.
    /// </summary>
    public PlayerController GetCachedLocalPlayer()
    {
        return localPlayer;
    }
}
