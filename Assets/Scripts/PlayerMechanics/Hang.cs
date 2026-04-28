using Unity.Mathematics;
using UnityEngine;
using VicGenLib.Calc;
using VicGenLib.Controllers;
using VicGenLib.Logic;

public class Hang : MonoBehaviour
{

    public bool canHang, colisionDetectada;

    public ControlsDetector controls;

    private Rigidbody rb;

    public bool colgado, hasLeftFree, hasRightFree, ajustarHang;

    public RaycastHit raycastAjuste;

    public float longitudRaycastHang;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        longitudRaycastHang = 1.5f;

        controls = this.gameObject.GetComponent<Movement>().controls;

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Casts();
        DetectHang();
    }

    private void DetectHang()
    {

        Debug.DrawLine(this.gameObject.transform.GetChild(1).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).gameObject.transform.position + this.gameObject.transform.GetChild(1).gameObject.transform.forward + new Vector3 (0, this.gameObject.transform.localScale.y), Color.yellow, 0.1f);
        if(canHang)
        {   
            Debug.Log("can hang");
            if (controls.M2M)
            {
                //fix para contrarrestar la gravedad al estar colgado
                rb.linearVelocity = new Vector3(rb.linearVelocity.x /2, 4, rb.linearVelocity.z /2);

                colgado = true;
            }

            if (controls.M2S)
            {
                colgado = false;
                canHang = false;
            }
        }
        else
        {
            colgado = false;
            
        }

        if(!Physics.Raycast(this.gameObject.transform.position + new Vector3 (0.5f, 0, 0), this.gameObject.transform.forward, 0.8f))
        {
            hasRightFree = true;
        }
        else
        {
            hasRightFree = false;
        }

        if(!Physics.Raycast(this.gameObject.transform.position + new Vector3 (-0.5f, 0, 0), this.gameObject.transform.forward, 0.8f))
        {
            hasLeftFree = true;
        }
        else
        {
            hasLeftFree = false; 
        }

        if (Physics.Raycast(this.gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.3f), this.gameObject.transform.forward, out raycastAjuste, longitudRaycastHang))
        {
            
            ajustarHang = true;
            
        }

        else
        {
            ajustarHang = false;
        }

        //!RayCasts.CustomCast(this.gameObject, this.gameObject.transform.position + this.gameObject.transform.forward, new Vector3(0, this.gameObject.transform.localScale.y / 2, 0), 1f
    }

    private void Casts()
    {
        //Deteccion 360

        for(int i = 0; i < this.gameObject.transform.GetChild(1).childCount; i++)
        {
            //el primer raycast verifica que haya sitio para agarrarse (hueco)
            //el segundo verifica que haya un objeto al que agarrarse
            if(!Physics.Raycast(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, longitudRaycastHang) && 
                Physics.Raycast(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.3f), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, longitudRaycastHang))
            {
                colisionDetectada = true;
            }
        }

        if (colisionDetectada)
        {
            canHang = true;
        }
        else
        {
            canHang = false;
        }

        colisionDetectada = false;
    }
}
