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

    public bool colgado, hasLeftFree, hasRightFree, ajustarHang, ajusteDetectado, usarGravedad;

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
        DetectHang();
        Casts();
    }

    private void DetectHang()
    {

        //Debug.DrawLine(this.gameObject.transform.GetChild(1).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).gameObject.transform.position + this.gameObject.transform.GetChild(1).gameObject.transform.forward + new Vector3 (0, this.gameObject.transform.localScale.y), Color.yellow, 0.1f);
        if(canHang)
        {   
            Debug.Log("can hang");
            if (controls.M2M)
            {
                //fix para contrarrestar la gravedad al estar colgado
                if (ajustarHang)
                {
                    usarGravedad = true;
                    this.gameObject.transform.position += new Vector3(0,0.05f,0);  
                }
                else
                {
                    usarGravedad = false;
                    rb.linearVelocity = Vector3.zero;
                }
                
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

        if (!colgado)
        {
            usarGravedad = true;
        }

        //!RayCasts.CustomCast(this.gameObject, this.gameObject.transform.position + this.gameObject.transform.forward, new Vector3(0, this.gameObject.transform.localScale.y / 2, 0), 1f
    }

    private void Casts()
    {
        Debug.Log($"colgado {colgado}");
        //Deteccion 360
        for(int i = 0; i < this.gameObject.transform.GetChild(1).childCount; i++)
        {
            RaycastHit hitAjuste;
            if(colgado)
            {
                Physics.Raycast(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y +0.15f), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, out hitAjuste, longitudRaycastHang);

                Debug.Log($"colider hit ajuste{hitAjuste.collider}");

                if(hitAjuste.collider != null && colgado)
                {
                    ajusteDetectado = true;
                }
                else
                {
                    ajusteDetectado = false;
                }

                Debug.Log($"ajusteDetectado {ajusteDetectado}");
            }

            if (ajusteDetectado)
            {
                break;
            }
        }

        for(int i = 0; i < this.gameObject.transform.GetChild(1).childCount; i++)
        {
            RaycastHit hitEspacioDisp, hitObjeto;
            //el primer raycast verifica que haya sitio para agarrarse (hueco)
            //el segundo verifica que haya un objeto al que agarrarse
            
            
            Physics.Raycast(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, out hitEspacioDisp, longitudRaycastHang);
            Physics.Raycast(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.1f), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, out hitObjeto, longitudRaycastHang);

            Debug.DrawRay(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y +0.15f), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, Color.blue, 0.01f);
            //Debug.DrawRay(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, Color.blue, 0.01f);
            //Debug.DrawRay(this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.3f), this.gameObject.transform.GetChild(1).GetChild(i).gameObject.transform.forward, Color.blue, 0.01f);

            

            if(hitEspacioDisp.collider == null && hitObjeto.collider != null)
            {
                canHang = true;
            }
            else
            {
                canHang = false;
            }

            if(hitObjeto.collider != null)
            {
                colisionDetectada = true;
            }
            else
            {
                colisionDetectada = false;
            }

            if (ajusteDetectado && colgado)
            {
                ajustarHang = true;
            }
            else
            {
                ajustarHang = false;
            }
        }
    }

    /*private void Casts()
    {
        //Deteccion 360
        

        
        for(int i = 0; i < this.gameObject.transform.GetChild(1).childCount; i++)
        {
            RaycastHit hitEspacioDisp, hitObjeto, hitAjuste;
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
    }*/
}
