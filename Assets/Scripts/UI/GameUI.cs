using System.Collections;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject configManagerObj;

    public ConfigManager configManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        configManagerObj = GameObject.FindWithTag("Config");

        configManager = configManagerObj.GetComponent<ConfigManager>();

        StartCoroutine(MostrarFPS());
    }

    // Update is called once per frame
    void Update()
    {
        if (configManager.mostrarFPS)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator MostrarFPS()
    {
        while (true)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"FPS: {VicGenLib.Logic.GUI.PassFramesToText()}";

            yield return new WaitForSeconds(0.75f);
        }
    }
}
