using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using VicGenLib.Logic;

public class Movement : MonoBehaviour
{

    [Header("Solo es necesario asignar aqui los controles")]

    public ControlsDetector controls;

    private Animator animator;

    private Rigidbody rb;

    private RaycastHit raycastInclinacion;

    [SerializeField] private float velocidad;

    public float velocidadBase, fuerzaSaltoBase = 100, fuerzaSalto, coyoteTimeBase, anguloInclinacionSuelo;

    public float coyoteTime = 0.2f, cooldownSaltoHang = 0.6f;
    private int alreadyLoaded;

    public bool enSuelo, coyote, colisionando, alreadyActivated;

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
        animator = this.gameObject.GetComponent<Animator>();

        rb = this.gameObject.GetComponent<Rigidbody>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMov();

        HangAdditionalLogic();
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

            cooldownSaltoHang = 0.6f;
        }

        coyote = false;
    }

    void OnCollisionStay(Collision collision)
    {
        colisionando = true;
        if(Physics.Raycast(this.gameObject.transform.position, transform.up, 1f))
        {
            Debug.Log("DOU");
            enSuelo = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {

        colisionando = false;

        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }

        coyote = true;
    }

    private void Movimiento()
    {

        fuerzaSalto = fuerzaSaltoBase;

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
        Physics.Raycast(gameObject.transform.position, Vector3.down, out raycastInclinacion, 1f);

        anguloInclinacionSuelo = Vector3.Angle(Vector3.up, raycastInclinacion.normal);

        Debug.Log($"angulo inclinacion del suelo {anguloInclinacionSuelo}");

        if (this.gameObject.GetComponent<Hang>().colgado)
        {
            enSuelo = false;
        }

        if (controls.SpaceM && enSuelo && anguloInclinacionSuelo < 30 && anguloInclinacionSuelo != 0)
        {

            
            rb.AddForce(Vector3.up * fuerzaSalto * 5 * 9.8f * Time.deltaTime, ForceMode.Impulse);
            
            Debug.Log($"Vel Y {rb.linearVelocity.y}");
        }

        if(this.gameObject.GetComponent<Hang>().usarGravedad)
        rb.AddForce(Vector3.up * 7.5f * -9.8f, ForceMode.Acceleration);
    }

    private void CoyoteTime()
    {
        coyoteTime -= Time.deltaTime;

        if (coyoteTime < 0)
        {
            coyote = false;
        }
        else
        {
            coyote = true;
        }

        if (controls.SpaceM && enSuelo || this.gameObject.GetComponent<Hang>().colgado)
        {
            coyote = false;
        }

        if (enSuelo && rb.linearVelocity.y <= 0)
        {
            coyoteTime = coyoteTimeBase;
        }

        if(coyote == true && controls.SpaceM && !enSuelo && !this.gameObject.GetComponent<Hang>().colgado)
        {
            coyoteTime = 0;
            coyote = false;

            rb.AddForce(Vector3.up * fuerzaSalto * 10 * 9.8f * Time.deltaTime, ForceMode.Impulse);
        }

    }

    private void HangAdditionalLogic()
    {

        if (this.gameObject.GetComponent<Hang>().colgado)
        {
            this.gameObject.GetComponent<Hang>().colgado = false;

            if (controls.SpaceM)
            {
                rb.AddForce(Vector3.up * fuerzaSalto * 10 * 9.8f * Time.deltaTime, ForceMode.Impulse);
            }
        }

        if (this.gameObject.GetComponent<Hang>().colgado)
        {
            if(colisionando == false)
            {
                this.gameObject.transform.position = this.gameObject.transform.position + transform.forward * 0.05f;
            }

            this.gameObject.GetComponent<Hang>().longitudRaycastHang = 7f; 
        }

        else
        {
            this.gameObject.GetComponent<Hang>().longitudRaycastHang = 5f;
        }

    }


}
