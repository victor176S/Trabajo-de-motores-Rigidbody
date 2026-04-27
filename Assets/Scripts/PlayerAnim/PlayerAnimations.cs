using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Rigidbody rb;

    private Animator animator;

    private ControlsDetector controls;

    private Movement movement;

    private Hang hangControl;

    private float movingHang, moving;

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

        animator.SetFloat("VelY", rb.linearVelocity.y);
        animator.SetFloat("HangMove", movingHang);

        animator.SetBool("IsMoving", moving != 0);
        animator.SetBool("EnSuelo", movement.enSuelo);
        animator.SetBool("IsRunning", controls.ShiftM);
        animator.SetBool("Hanging", hangControl.colgado);
        

        if(controls.SpaceM && movement.enSuelo)
        animator.SetTrigger("Salto");
    }

    private void ValuesAssign()
    {
        if (controls.WM)
        {
            moving = -2;
        }

        if (controls.AM)
        {
            movingHang = -1;
            moving = -1;
        }

        if (controls.DM)
        {
            movingHang = 1;
            moving = 1;
        }

        if (controls.SM)
        {
            moving = 2;
        }

        if(!controls.DM && !controls.AM)
        {
            movingHang = 0;
            
        }

        if (!Input.anyKey)
        {
            moving = 0;
        }
    }
}
