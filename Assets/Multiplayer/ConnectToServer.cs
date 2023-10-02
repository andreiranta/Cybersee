using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("An error occured while connecting...");
            SceneManager.LoadScene("MainMenu");
            return;
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Successfully joined the lobby");

        RoomOptions room = new RoomOptions();
        room.IsVisible = false;
        PhotonNetwork.JoinOrCreateRoom("test_room", room, PhotonNetwork.CurrentLobby);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room " + PhotonNetwork.CurrentRoom.Name.ToString() + " with " + PhotonNetwork.CurrentRoom.PlayerCount + " players.");
        SceneManager.LoadScene("VrRoom");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError("error connecting to room\ncode: " + returnCode + " message: " + message);
    }
}