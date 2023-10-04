using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    private float minX = 15;
    private float maxX = 70;

    private float cordY = 5;

    private float minZ = -35;
    private float maxZ = 20;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Vector3 position = new Vector3(Random.Range(minX, maxX), cordY, Random.Range(minZ, maxZ));
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("OVRCameraRig Variant", position, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
