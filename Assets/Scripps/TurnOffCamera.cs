using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TurnOffCamera : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
        {
            GetComponent<Camera>().enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
