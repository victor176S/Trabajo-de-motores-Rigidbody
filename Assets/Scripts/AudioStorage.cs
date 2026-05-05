using UnityEngine;

public class AudioStorage : MonoBehaviour
{
    public AudioClip[] audios;

    public GameObject controlsObject, player, configManagerObj;

    public ControlsDetector controls;

    public Movement movement;

    public ConfigManager configManager;

    public bool alreadyAssigned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(AssignObjects), 5f);
    }



    // Update is called once per frame
    void Update()
    {
        if (!alreadyAssigned)
        {
            for(int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<AudioSource>().volume = configManager.volumen / 100;
            }

            alreadyAssigned = true;
        }

        if(controls.SpaceM && movement.enSuelo && movement.rb.linearVelocity.y > 6)
        {
            Debug.Log("Sonido");
            this.gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().PlayOneShot(audios[0]);
        }
    }

    void AssignObjects()
    {
        configManagerObj = GameObject.FindWithTag("Config");

        configManager = configManagerObj.GetComponent<ConfigManager>();

        controlsObject = GameObject.FindWithTag("Controls");

        controls = controlsObject.GetComponent<ControlsDetector>();

        player = GameObject.FindWithTag("Player");

        movement = player.GetComponent<Movement>();
    }
}
