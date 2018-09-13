using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject NetworkManagerPrefab;
    private CustomNetworkManager _networkManager; // Dont use this directly
    protected CustomNetworkManager NetworkManager
    {
        get
        {
            // First attempt to set/get it based on singleton pattern
            _networkManager = CustomNetworkManager.instance;

            if (_networkManager == null)
            {
                // If still null, then the GameObject has not been instantiated
                Instantiate(NetworkManagerPrefab);
                _networkManager = CustomNetworkManager.instance;
            }

            return _networkManager;
        }
    }

    public void HostGame()
    {
        Debug.LogFormat("Hosting on {0}:{1}", NetworkManager.networkAddress, NetworkManager.networkPort);

        NetworkManager.StartHost();

        if (!NetworkManager.isNetworkActive)
            Debug.LogWarning("Failed to host on LAN");
    }

    public void JoinGame()
    {
        Debug.LogFormat("Joining {0}:{1}", NetworkManager.networkAddress, NetworkManager.networkPort);

        NetworkManager.StartClient();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
