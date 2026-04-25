using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Rigidbody rb;

    private Animator animator;

    private ControlsDetector controls;

    private Movement movement;

    private Hang hangControl;

    private float moving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        hangControl = this.gameObject.GetComponent<Hang>();

        animator = this.gameObject.GetComponent<Animator>();

        movement = this.gameObject.GetComponent<Movement>();

        controls = movement.controls;
    }

    // Update is called once per frame
    void Update()
    {
        ValuesAssign();

        Animations();
    }

    private void Animations()
    {

        Debug.Log($"{Mathf.Abs(rb.linearVelocity.x)}, {Mathf.Abs(rb.linearVelocity.z)}, {controls.ShiftM}");

        animator.SetFloat("VelY", Mathf.Abs(rb.linearVelocity.y));
        animator.SetFloat("HangMove", moving);

        animator.SetBool("IsMoving", (rb.linearVelocity.x > 0.1f || rb.linearVelocity.x < -0.1f) || (rb.linearVelocity.z > 0.1f || rb.linearVelocity.z < -0.1f));
        animator.SetBool("EnSuelo", movement.enSuelo);
        animator.SetBool("IsRunning", (Mathf.Abs(rb.linearVelocity.x) > 0.1f || Mathf.Abs(rb.linearVelocity.z) > 0.1f) && controls.ShiftM);
        animator.SetBool("Hanging", hangControl.colgado);
        

        if(controls.SpaceM && movement.enSuelo)
        animator.SetTrigger("Salto");
    }

    private void ValuesAssign()
    {
        if (controls.AM)
        {
            moving = -1;
        }

        if (controls.DM)
        {
            moving = 1;
        }

        if(!controls.DM && !controls.AM)
        {
            moving = 0;
        }
    }
}
