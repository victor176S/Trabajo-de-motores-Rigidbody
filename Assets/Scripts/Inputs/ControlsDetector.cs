using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using VicGenLib.Controllers;

public class ControlsDetector : MonoBehaviour
{

    //Presionar
    public bool A, W, S, D, Space, Shift, M1, M2;
    //Mantener
    public bool AM, WM, SM, DM, SpaceM, ShiftM, M1M, M2M;
    //Soltar
    public bool AS, WS, SS, DS, SpaceS, ShiftS, M1S, M2S;
    public float sensX, sensY, downAnglesLimit, upAnglesLimit;
    public Vector2 mouseMov;
    public float xRotation, yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controles();
    }

    public void Controles()
    {

        //A

        A = BaseControls.PMR(0, KeyCode.A);
        AM = BaseControls.PMR(1, KeyCode.A);
        AS = BaseControls.PMR(2, KeyCode.A);

        //W

        W = BaseControls.PMR(0, KeyCode.W);
        WM = BaseControls.PMR(1, KeyCode.W);
        WS = BaseControls.PMR(2, KeyCode.W);

        //S

        S = BaseControls.PMR(0, KeyCode.S);
        SM = BaseControls.PMR(1, KeyCode.S);
        SS = BaseControls.PMR(2, KeyCode.S);

        //D

        D = BaseControls.PMR(0, KeyCode.D);
        DM = BaseControls.PMR(1, KeyCode.D);
        DS = BaseControls.PMR(2, KeyCode.D);

        //Space

        Space = BaseControls.PMR(0, KeyCode.Space);
        SpaceM = BaseControls.PMR(1, KeyCode.Space);
        SpaceS = BaseControls.PMR(2, KeyCode.Space);

        //Shift

        Shift = BaseControls.PMR(0, KeyCode.LeftShift);
        ShiftM = BaseControls.PMR(1, KeyCode.LeftShift);
        ShiftS = BaseControls.PMR(2, KeyCode.LeftShift);

        //M1

        M1 = BaseControls.PMR(0, KeyCode.Mouse0);
        M1M = BaseControls.PMR(1, KeyCode.Mouse0);
        M1S = BaseControls.PMR(2, KeyCode.Mouse0);

        //M2

        M2 = BaseControls.PMR(0, KeyCode.Mouse1);
        M2M = BaseControls.PMR(1, KeyCode.Mouse1);
        M2S = BaseControls.PMR(2, KeyCode.Mouse1);

        //movimiento ratón

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        //limite de grados arriba y abajo
        xRotation = Mathf.Clamp(xRotation, downAnglesLimit, upAnglesLimit);
    }
}
