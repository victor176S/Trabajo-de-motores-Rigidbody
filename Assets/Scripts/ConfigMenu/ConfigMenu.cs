using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigMenu : MonoBehaviour
{

    public GameObject configMenu, configValues, menu, lobby;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfigToggle()
    {
        configMenu.SetActive(!configMenu.activeSelf);
        menu.SetActive(!configMenu.activeSelf);
    }

    public void OpenLobbyMenu()
    {
        lobby.SetActive(!lobby.activeSelf);;
    }

    public void Close()
    {
        Application.Quit();
    }

    public void MostrarFPS()
    {
        configValues.GetComponent<ConfigValues>().mostrarFPS = !configValues.GetComponent<ConfigValues>().mostrarFPS;
    }
}
