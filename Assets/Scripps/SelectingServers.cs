using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class SelectingServers : NetworkBehaviour
{
    [SerializeField] private Button SubmitBtn;
    [SerializeField] private TMP_InputField TextFieldIP;
    [SerializeField] private TMP_InputField TextFieldPort;

    // Update is called once per frame
    void Start()
    {
        SubmitBtn.onClick.AddListener(() =>
        {
            ChangeIP();
        });
    }
    public void ChangeIP()
    {

        if (ushort.TryParse(TextFieldPort.text, out ushort port))
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(TextFieldIP.text.Trim(), port);
        }

    }
}
