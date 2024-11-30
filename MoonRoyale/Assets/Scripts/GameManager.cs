using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            hostButton.interactable = false;
            clientButton.interactable = false;
        });
        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            hostButton.interactable = false;
            clientButton.interactable = false;
        });
    }
}
