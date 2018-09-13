using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{

    public static CustomNetworkManager instance;
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
    
    public override void OnStartServer()
    {
        //Debug.Log("OnStartServer");

        base.OnStartServer(); // Maybe should not call, didnt in Robocode, dunno.
    }

    public override void OnStopServer()
    {
        //Debug.Log("OnStopServer");

        base.OnStopServer(); // Maybe should not call, didnt in Robocode, dunno.
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        //Debug.Log("OnClientConnect on when isServer: " + LobbyManager.IsServer);

        base.OnClientConnect(conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        //Debug.Log("OnClientDisconnect");

        base.OnClientDisconnect(conn);
    }

    public override void OnStopClient()
    {
        //Debug.Log("OnStopClient");

        base.OnStopClient();
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        //Debug.Log("OnServerDisconnect: " + conn.connectionId.ToString());

        // Will get disconnect error when clients StopsClient (https://forum.unity3d.com/threads/networkmanager-error-server-client-disconnect-error-1.439245/)
        base.OnServerDisconnect(conn);
    }

    /// <summary>
    /// playerControllerId is unique per player, multiple players can play from the same game instance, but since we have one player per connection we dont need to use it.
    /// </summary>
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //Debug.Log("Joined a player with connectionId: " + conn.connectionId.ToString());

        base.OnServerAddPlayer(conn, playerControllerId);
    }

    public void StopOrLeaveGame()
    {
        if (NetworkServer.active)
            StopHost();
        else
            StopClient();
    }

}