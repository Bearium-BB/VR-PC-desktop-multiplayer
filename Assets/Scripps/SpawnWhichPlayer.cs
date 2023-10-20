using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnWhichPlayer : NetworkBehaviour
{

    Transform spawnedGameObject;
    private void Awake()
    {
        //if (!IsOwner)
        if (OwnerClientId != gameObject.GetComponent<NetworkObject>().OwnerClientId)
        {
            return;

        }
        StartCoroutine(WaitForFunction());
    }

    public Transform[] GameObjectPrefab;
    private void SelectCharacter(ulong OCD)
    {
        Debug.Log(OwnerClientId);
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            spawnedGameObject = Instantiate(GameObjectPrefab[1]);
            spawnedGameObject.GetComponent<NetworkObject>().SpawnWithOwnership(OCD, true);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            spawnedGameObject = Instantiate(GameObjectPrefab[0]);
            spawnedGameObject.GetComponent<NetworkObject>().SpawnWithOwnership(OCD, true);
        }
        else
        {
            spawnedGameObject = Instantiate(GameObjectPrefab[1]);
            spawnedGameObject.GetComponent<NetworkObject>().SpawnWithOwnership(OCD, true);
        }
    }
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(3);
        SelectCharacter(OwnerClientId);
    }
}
