using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigValues : MonoBehaviour
{

    public Slider volumen;

    public GameObject configManagerObject, configMenu, FPSButton;

    public ConfigManager configManager;

    public bool mostrarFPS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        configManagerObject = GameObject.FindWithTag("Config");
    }

    // Update is called once per frame
    void Update()
    {
        configManager = configManagerObject.GetComponent<ConfigManager>();

        configManager.volumen = volumen.value;

        configManager.mostrarFPS = mostrarFPS;

        volumen.gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Volumen {volumen.value}%";

        if (mostrarFPS)
        {
            FPSButton.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Si";
        }
        else
        {
            FPSButton.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "No";
        }
    }
}
