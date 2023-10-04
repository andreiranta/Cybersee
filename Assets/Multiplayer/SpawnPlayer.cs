using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX = 15;
    public float maxX = 70;

    public float cordY = 5;

    public float minZ = -35;
    public float maxZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(Random.Range(minX, maxX), cordY, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
