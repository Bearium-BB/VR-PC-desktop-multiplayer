using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 10;

    // Reference to the player's Transform component
    private Transform playerTransform;

    // Called when the script instance is being loaded.
    private void Awake()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsOwner)
            return;
        // Capture player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Convert input into a movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;

        // Send movement commands to the server
        if (IsServer)
        {
            ServerMoveServerRpc(movement);
        }
        else if (IsOwner)
        {
            // Send the movement command to the server
            SendServerMove(movement);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void ServerMoveServerRpc(Vector3 movement)
    {
        // Server-side logic to validate and apply the movement
        playerTransform.Translate(movement * Time.deltaTime);
    }

    private void SendServerMove(Vector3 movement)
    {
        // Send a movement command to the server
        ServerMoveServerRpc(movement);
    }

}
