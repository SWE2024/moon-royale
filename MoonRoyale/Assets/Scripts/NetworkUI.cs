using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;

    void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            serverButton.interactable = false;
            clientButton.interactable = false;

            NetworkManager.Singleton.StartHost();
        });
        serverButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            serverButton.interactable = false;
            clientButton.interactable = false;

            NetworkManager.Singleton.StartServer();
        });
        clientButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            serverButton.interactable = false;
            clientButton.interactable = false;

            NetworkManager.Singleton.StartClient();
        });
    }
}
