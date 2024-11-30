using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkController : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    void Awake()
    {
        NetworkController.InitialiseDb();

        hostButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            clientButton.interactable = false;

            // create the database for the game and start hosting
            NetworkManager.Singleton.StartHost();
            NetworkController.CreateGame();
        });
        clientButton.onClick.AddListener(() =>
        {
            hostButton.interactable = false;
            clientButton.interactable = false;

            NetworkManager.Singleton.StartClient();
        });
    }

    public static void InitialiseDb()
    {
        // create the database here
    }

    public static void CreateGame()
    {
        // create a lobby and add to db
    }

    public static void AddPlayerToDb(ulong id)
    {
        // add the player to the lobby database
    }

    public static int GetGameId()
    {
        return 0;
    }
}
