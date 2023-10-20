using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostrBtn;
    [SerializeField] private Button clientBtn;


    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //serverBtn.onClick.AddListener(() =>
        //{
        //    NetworkManager.Singleton.StartServer();
        //});
        hostrBtn.onClick.AddListener(() =>
        {
            test1();
        });
        clientBtn.onClick.AddListener(() =>
        {
            test2();        
        });
    }

    public void test1()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("Main VR Scene", LoadSceneMode.Single);
    }

    public void test2()
    {
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.SceneManager.LoadScene("Main VR Scene", LoadSceneMode.Single);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SendtestRpc(string message)
    {
        HandletestRpc(message);    
    }

    [ClientRpc]
    public void HandletestRpc(string message)
    {
        NetworkManager.Singleton.SceneManager.LoadScene("Main VR Scene", LoadSceneMode.Single);

    }
}
