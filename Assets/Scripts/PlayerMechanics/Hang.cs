using Unity.Mathematics;
using UnityEngine;
using VicGenLib.Calc;
using VicGenLib.Controllers;
using VicGenLib.Logic;

public class Hang : MonoBehaviour
{

    public bool canHang;

    public ControlsDetector controls;

    private Rigidbody rb;

    public bool colgado, hasLeftFree, hasRightFree, ajustarHang;

    public RaycastHit raycastAjuste;

    public float longitudRaycastHang;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        longitudRaycastHang = 1;

        controls = this.gameObject.GetComponent<Movement>().controls;

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectHang();
    }

    private void DetectHang()
    {

        this.gameObject.transform.GetChild(1).gameObject.transform.rotation = quaternion.Euler(0, this.gameObject.transform.GetChild(1).gameObject.transform.rotation.y + 0.36f, 0);

        Debug.DrawLine(this.gameObject.transform.GetChild(1).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).gameObject.transform.position + this.gameObject.transform.GetChild(1).gameObject.transform.forward + new Vector3 (0, this.gameObject.transform.localScale.y), Color.yellow, 0.1f);
        if(!Physics.Raycast(this.gameObject.transform.GetChild(1).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.GetChild(1).gameObject.transform.forward, longitudRaycastHang) && 
            Physics.Raycast(this.gameObject.transform.GetChild(1).gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.3f), this.gameObject.transform.GetChild(1).gameObject.transform.forward, longitudRaycastHang))
        {   
            Debug.Log("can hang");
            if (controls.M2M)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x / 2, 1.176f, rb.linearVelocity.z /2);

                colgado = true;
            }

            if (controls.M2S)
            {
                colgado = false;
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
}
