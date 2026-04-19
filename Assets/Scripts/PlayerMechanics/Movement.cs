using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    [Header("Solo es necesario asignar aqui los controles")]

    public ControlsDetector controls;

    private Rigidbody rb;

    [SerializeField] private float velocidad;

    public float velocidadBase, fuerzaSaltoBase = 100, fuerzaSalto, coyoteTimeBase;

    public float coyoteTime = 0.2f;
    private int alreadyLoaded;

    public bool enSuelo, coyote;

    void Awake()
    {
       velocidadBase = velocidad; 
       fuerzaSalto = fuerzaSaltoBase;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnLevelWasLoaded(int level)
    {
        this.gameObject.transform.GetChild(0).gameObject.transform.localRotation = quaternion.Euler(0,0,0);
    }
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMov();
    }

    void FixedUpdate()
    {
        Movimiento();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo") && !this.gameObject.GetComponent<Hang>().colgado)
        {
            enSuelo = true;
        }

        coyote = false;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }

        coyote = true;
    }

    private void Movimiento()
    {

        CoyoteTime();

        Caminar();

        Salto();


    }

    private void CameraMov()
    {

        //Movimiento ratón

        this.gameObject.transform.rotation = Quaternion.Euler(0, controls.yRotation, 0);
        this.gameObject.transform.GetChild(0).gameObject.transform.localRotation = Quaternion.Euler(controls.xRotation, 0, 0);

    }

    private void Caminar()
    {

        if (controls.ShiftM)
        {
            velocidad = velocidadBase * 1.5f;
        }
        else
        {
            velocidad = velocidadBase; 
        }

        if (controls.AM)
        {
            rb.AddForce(-transform.right * velocidad, ForceMode.VelocityChange);
        }

        if (controls.WM)
        {
            rb.AddForce(transform.forward * velocidad, ForceMode.VelocityChange);
        }

        if (controls.SM)
        {
            rb.AddForce(-transform.forward * velocidad, ForceMode.VelocityChange);
        }

        if (controls.DM)
        {
            rb.AddForce(transform.right * velocidad, ForceMode.VelocityChange);
        }

        if (rb.linearVelocity.magnitude > velocidad)
        {
            Vector3 vel = rb.linearVelocity.normalized * velocidad;
            vel.y = rb.linearVelocity.y;
            rb.linearVelocity = vel;
        }
    }

    private void Salto()
    {

        if (this.gameObject.GetComponent<Hang>().colgado)
        {
            enSuelo = false;
        }

        if (controls.SpaceM && enSuelo || controls.SpaceM && this.gameObject.GetComponent<Hang>().colgado)
        {

            if (this.gameObject.GetComponent<Hang>().colgado)
            {
                fuerzaSalto = fuerzaSaltoBase;
                this.gameObject.GetComponent<Hang>().colgado = false;
            }
            else
            {
                fuerzaSalto = fuerzaSaltoBase;
            }

            rb.AddForce(Vector3.up * fuerzaSalto * 9.8f * Time.deltaTime, ForceMode.Impulse);
        }

        rb.AddForce(Vector3.up * 5 * -9.8f, ForceMode.Acceleration);

        if (coyote == true && controls.SpaceM)
        {
            coyote = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto * 9.8f * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void CoyoteTime()
    {

        if (coyoteTime < 0)
        {
            coyote = false;
        }

        if (controls.SpaceM && enSuelo || this.gameObject.GetComponent<Hang>().colgado)
        {
            coyote = false;
        }

        coyoteTime -= Time.deltaTime;

        if (enSuelo && rb.linearVelocity.y <= 0)
        {
            coyoteTime = coyoteTimeBase;
        }
    }

    private void HangAdditionalLogic()
    {

        if (this.gameObject.GetComponent<Hang>().has)

    }
}
