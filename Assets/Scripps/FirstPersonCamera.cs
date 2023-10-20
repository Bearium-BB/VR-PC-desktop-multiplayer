using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Unity.Netcode;
using UnityEngine;

public class FirstPersonCamera : NetworkBehaviour
{
    public GameObject player;
    public float mouseSensitivity = 2f;  // Mouse sensitivity for camera rotation
    public Vector3 Offset = Vector3.zero;

    public bool lockCamera = true;

    private float yaw = 0f;  // Rotation around the y-axis (yaw)
    private float pitch = 0f;  // Rotation around the x-axis (pitch)

    private void Start()
    {

    }

    private void LateUpdate()
    {
        if (!IsOwner)
            return;
        if (lockCamera)
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            SendServerMove(mouseX, mouseY);
        }
    }
    [ServerRpc(RequireOwnership = false)]
    private void ServerMoveServerRpc(float mouseX, float mouseY)
    {
        // Update yaw and pitch based on mouse movement
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);  // Limit the pitch to avoid camera flipping


        // Rotate the camera based on yaw and pitch
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Rotate the player object on the y-axis to match the camera's rotation
        player.transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        transform.position = player.transform.position + Offset;
    }

    private void SendServerMove(float mouseX, float mouseY)
    {
        // Send a movement command to the server
        ServerMoveServerRpc(mouseX, mouseY);
    }
}
