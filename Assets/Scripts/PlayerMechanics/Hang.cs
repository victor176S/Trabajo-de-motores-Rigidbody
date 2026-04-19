using UnityEngine;
using VicGenLib.Calc;
using VicGenLib.Controllers;
using VicGenLib.Logic;

public class Hang : MonoBehaviour
{

    public bool canHang;

    public ControlsDetector controls;

    private Rigidbody rb;

    public bool colgado, hasLeftFree, hasRightFree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

        Debug.DrawLine(this.gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.position + this.gameObject.transform.forward + new Vector3 (0, this.gameObject.transform.localScale.y), Color.yellow, 0.1f);
        if(!Physics.Raycast(this.gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y), this.gameObject.transform.forward , 1) && 
            Physics.Raycast(this.gameObject.transform.position + new Vector3 (0, this.gameObject.transform.localScale.y -0.3f), this.gameObject.transform.forward, 1))
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

        if(!Physics.Raycast(this.gameObject.transform.position + new Vector3 (0.5f, 0, 0), this.gameObject.transform.forward, 1))
        {
            hasRightFree = true;
        }
        else
        {
            hasRightFree = false;
        }

        if(!Physics.Raycast(this.gameObject.transform.position + new Vector3 (-0.5f, 0, 0), this.gameObject.transform.forward, 1))
        {
            hasLeftFree = true;
        }
        else
        {
            hasLeftFree = false; 
        }

        Debug.Log($"{hasLeftFree}, {hasRightFree}");

        //!RayCasts.CustomCast(this.gameObject, this.gameObject.transform.position + this.gameObject.transform.forward, new Vector3(0, this.gameObject.transform.localScale.y / 2, 0), 1f
    }
}
