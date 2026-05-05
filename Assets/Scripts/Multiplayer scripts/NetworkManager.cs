using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkManager instance;
    public NetworkRunner runnerPrefab;

    public static NetworkRunner runnerInstance;

    public int playerCount;

    public NetworkObject playerPrefab, controls;

    public NetworkObject[] players;

    [SerializeField] private string lobbyName = "default";

    [SerializeField] private Transform sessionListContentParent;

    [SerializeField] private GameObject sessionListEntryPrefab;

    [SerializeField] private Dictionary<string, GameObject> sessionListUiDictionary = new Dictionary<string, GameObject>();

    [SerializeField] private SceneAsset gameScene;

    [SerializeField] private SceneAsset lobbyScene;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
        runnerInstance = Instantiate(runnerPrefab);

       //Conexion con el servidor
        runnerInstance.JoinSessionLobby(SessionLobby.Shared, lobbyName);
    }

    public static void ReturnToLobby()
    {
        runnerInstance.Despawn(runnerInstance.GetPlayerObject(runnerInstance.LocalPlayer));

        runnerInstance.Shutdown(true, ShutdownReason.Ok);
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason reason)
    {
        SceneManager.LoadScene(lobbyScene.name);
    }

    //salas aleatorias

    public void CreateRandomSession()
    {
        int randomInt = Random.Range(1000, 9999);

        string randomSessionName = "Room-" + randomInt.ToString();

        runnerInstance.StartGame(new StartGameArgs()
        {
            Scene = SceneRef.FromIndex(GetSceneIndex(gameScene.name)),
            SessionName = randomSessionName,
            GameMode = GameMode.Shared,
            PlayerCount = 2,
            IsVisible = true,
        });
    }

    private int GetSceneIndex(string SceneName)
    {
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if(name == SceneName)
            {
                return i;
            }
        }

        return -1; //Error
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        DeleteOldSessionFromUI(sessionList);

        CompareLists(sessionList);
    }

    private void CompareLists(List<SessionInfo> sessionList)
    {
        foreach (SessionInfo session in sessionList)
        {
            if (sessionListUiDictionary.ContainsKey(session.Name))
            {
                UpdateEntryUI(session);
            }

            else
            {
                CreateEntryUI(session);
            }
        }
    }

    private void CreateEntryUI(SessionInfo session)
    {
        GameObject newEntry = Instantiate(sessionListEntryPrefab);

        newEntry.transform.parent = sessionListContentParent;

        SessionListEntry entryScript = newEntry.GetComponent<SessionListEntry>();

        sessionListUiDictionary.Add(session.Name, newEntry);

        entryScript.roomName.text = session.Name;

        entryScript.playerCount.text = session.PlayerCount.ToString() + "/" + session.MaxPlayers.ToString();

        entryScript.joinButton.interactable = session.IsOpen;

        newEntry.SetActive(session.IsVisible);
    }

    private void UpdateEntryUI(SessionInfo session)
    {
        sessionListUiDictionary.TryGetValue(session.Name, out GameObject newEntry);

        SessionListEntry entryScript = newEntry.GetComponent<SessionListEntry>();

        entryScript.roomName.text = session.Name;

        entryScript.playerCount.text = session.PlayerCount.ToString() + "/" + session.MaxPlayers.ToString();

        entryScript.joinButton.interactable = session.IsOpen;

        newEntry.SetActive(session.IsVisible);
    }

    private void DeleteOldSessionFromUI(List<SessionInfo> sessionList)
    {
        bool isContained = false;

        GameObject uiToDelete = null;

        foreach (KeyValuePair<string, GameObject> kvp in sessionListUiDictionary)
        {
            string sessionKey = kvp.Key;

            foreach (SessionInfo session in sessionList)
            {
                if(session.Name == sessionKey)
                {
                  isContained = true;
                  break;  
                }
            }
        }
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {

        
        
        if(player == runner.LocalPlayer)
        {
            NetworkObject playerObject = runner.Spawn(playerPrefab, Vector3.zero);
            runner.SetPlayerObject(player, playerObject);
        }
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, System.ArraySegment<byte> data)
    {
        
    }
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        /*Se supone que al cargar por completo la escena, busca todos los jugadores y prefabs de controles
        despues se asigna un prefab de control a cada jugador, para que se puedan manejar de forma independiente*/
        if(SceneManager.GetActiveScene().name == "Juego")
        {
            //placeholder de recuento de jugadores
            int playerCount = 0;

            List<GameObject> playersInGame = new List<GameObject>();
            List<GameObject> controls = new List<GameObject>();
            GameObject.FindGameObjectsWithTag("Player", playersInGame);
            GameObject.FindGameObjectsWithTag("Controls", controls);
            for(int i = 0; i < playerCount; i++)
            {
                players[i].GetComponent<Movement>().controls = controls[i].GetComponent<ControlsDetector>();
                players[i] = playersInGame[i].GetComponent<NetworkObject>();
            }
        }
        
        
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }
}
