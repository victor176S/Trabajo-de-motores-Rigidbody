using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace VicGenLib
{
    namespace Calc
    {
        public class Convert
        {
            public static int ToInt(float valor)
            {
                return (int)valor; 
            }
        }
        public class Sums
        {       
            public static float SumExample(float a, float b)
            {
                float c;

                c = a + b;

                    return c;
            }
        }

        public class Angles
        {
            public static Quaternion NormalToEulerAngles(Vector3 rotacion)
            {
                Quaternion rotacionNueva = Quaternion.Euler(rotacion / 57.295645530939648586707410236822f);

                return rotacionNueva;
            }

            public static Quaternion NormalToEulerAngles(float rotacionX, float rotacionY, float rotacionZ)
            {
                Quaternion rotacionNueva = Quaternion.Euler(rotacionX / 57.295645530939648586707410236822f,
                                                            rotacionY / 57.295645530939648586707410236822f, 
                                                            rotacionZ / 57.295645530939648586707410236822f);

                return rotacionNueva;
            }

            public static float NormalToEulerSingleAngle(float rotacion)
            {
                float rotacionNueva = rotacion / 57.295645530939648586707410236822f;

                return rotacionNueva;
            }

            public static Vector3 EulerToNormalAngles(Quaternion rotacion)
            {
                Vector3 rotacionNueva = new Vector3(rotacion.x * 57.295645530939648586707410236822f,
                                                    rotacion.y * 57.295645530939648586707410236822f,
                                                    rotacion.z * 57.295645530939648586707410236822f);

                return rotacionNueva;
            }

            /*public static Quaternion AddEulerQuaternions(Quaternion quaternion1, Quaternion quaternion2)
            {
                
            }*/

            public static float ModularClamp(float val, float min, float max, float rangemin = -180f, float rangemax = 180f) 
            {
                var modulus = Mathf.Abs(rangemax - rangemin);
                if((val %= modulus) < 0f) val += modulus;
                return Mathf.Clamp(val + Mathf.Min(rangemin, rangemax), min, max);
            }
        }

        //realmente no soluciono mucho, pero al menos lo tengo aqui por si me olvido de como se hace

        public class Counters
        {
            public static float FpsIndependentCounter(float tiempo)
            {
               tiempo += Time.deltaTime; 

               return tiempo;
            }

            public static float FpsIndependentCounter(float tiempo, float rapidez)
            {
               tiempo += rapidez * Time.deltaTime; 

               return tiempo;
            }

            public static float FpsIndependentCounterInt(float tiempo)
            {
               tiempo += Time.deltaTime;

               return tiempo;
            }

            public static float FpsIndependentCounterIntCustom(float tiempo, float rapidez)
            {
               tiempo += rapidez * Time.deltaTime;

               return tiempo;
            }
        }

        public class Movement
        {       

            //Usar en Update
            /*Hace el lerp más facil teniendo solo que pasar las variables*/

            public static UnityEngine.Vector3 SimplerLerp(GameObject objeto, GameObject startPoint, GameObject endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.transform.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(Transform objeto, GameObject startPoint, GameObject endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(Transform objeto, Transform startPoint, GameObject endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(Transform objeto, GameObject startPoint, Transform endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.transform.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(GameObject objeto, Transform startPoint, GameObject endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.transform.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(GameObject objeto, Transform startPoint, Transform endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.transform.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(GameObject objeto, GameObject startPoint, Transform endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.transform.position = UnityEngine.Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }

            public static UnityEngine.Vector3 SimplerLerp(Transform objeto, Transform startPoint, Transform endPoint, float lerpTime, AnimationCurve lerpCurve, float timeElapsed,out float timeElapsedOutPut)
            {

                float t = timeElapsed / lerpTime;

                t = Mathf.Clamp01(t);

                objeto.position = UnityEngine.Vector3.Lerp(startPoint.position, endPoint.position, lerpCurve.Evaluate(t));

                timeElapsed += Time.deltaTime;

                timeElapsedOutPut = timeElapsed;

                return objeto.transform.position;
            }
        }   
    }

    namespace Controllers
    {
        public class MovBase
        {
        public static UnityEngine.Vector3 SimplePlayerMovement(GameObject objeto)
        {
            if(Input.GetKey(KeyCode.W))
            {
                objeto.transform.position += new UnityEngine.Vector3(0,0,0.1f);
            }

            if(Input.GetKey(KeyCode.S))
            {
                objeto.transform.position += new UnityEngine.Vector3(0,0,-0.1f);
            }

            if(Input.GetKey(KeyCode.A))
            {
                objeto.transform.position += new UnityEngine.Vector3(-0.1f,0,0);
            }

            if(Input.GetKey(KeyCode.D))
            {
                objeto.transform.position += new UnityEngine.Vector3(0.1f,0,0);
            }

            return objeto.transform.position;
        }

        public static UnityEngine.Vector3 SimplePlayerMovement(GameObject objeto, float velocidad)
        {
            if(Input.GetKey(KeyCode.W))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0,0,0.1f * velocidad);
            }

            if(Input.GetKey(KeyCode.S))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0,0,-0.1f * velocidad);
            }

            if(Input.GetKey(KeyCode.A))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(-0.1f,0,0 * velocidad);
            }

            if(Input.GetKey(KeyCode.D))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0.1f,0,0 * velocidad);
            }

            return objeto.transform.position;
        }

        public static UnityEngine.Vector3 SimplePlayerMovementCustom(GameObject objeto, KeyCode codeForward, KeyCode codeBackwards, KeyCode codeLeft, KeyCode codeRight)
        {
            if(Input.GetKey(codeForward))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0,0,0.1f);
            }

            if(Input.GetKey(codeBackwards))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0,0,-0.1f);
            }

            if(Input.GetKey(codeLeft))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(-0.1f,0,0);
            }

            if(Input.GetKey(codeRight))
            {
                objeto.transform.localPosition += new UnityEngine.Vector3(0.1f,0,0);
            }

            return objeto.transform.position;
        }

        public static UnityEngine.Vector3 SimplePlayerMovementRB(GameObject objeto, ForceMode modo)
        {
            if(Input.GetKey(KeyCode.W))
            {
                objeto.GetComponent<Rigidbody>().AddForce(0, 0, 1f, modo);
            }

            if(Input.GetKey(KeyCode.S))
            {
                objeto.GetComponent<Rigidbody>().AddForce(0, 0, -1f, modo);
            }

            if(Input.GetKey(KeyCode.A))
            {
                objeto.GetComponent<Rigidbody>().AddForce(-1f, 0, 0, modo);
            }

            if(Input.GetKey(KeyCode.D))
            {
                objeto.GetComponent<Rigidbody>().AddForce(1f, 0, 0, modo);
            }

            return objeto.transform.position;
        }

        public static UnityEngine.Vector3 SimplePlayerMovementRB(GameObject objeto, ForceMode modo, float velocidad)
        {
            if(Input.GetKey(KeyCode.W))
            {
                objeto.GetComponent<Rigidbody>().AddForce(0, 0, 1f * velocidad, modo);
            }

            if(Input.GetKey(KeyCode.S))
            {
                objeto.GetComponent<Rigidbody>().AddForce(0, 0, -1f * velocidad, modo);
            }

            if(Input.GetKey(KeyCode.A))
            {
                objeto.GetComponent<Rigidbody>().AddForce(-1f * velocidad, 0, 0, modo);
            }

            if(Input.GetKey(KeyCode.D))
            {
                objeto.GetComponent<Rigidbody>().AddForce(1f * velocidad, 0, 0, modo);
            }

            return objeto.transform.position;
        }


        public static UnityEngine.Vector3 PlayerJumpRB(GameObject objeto, ForceMode modo, float fuerza)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                objeto.GetComponent<Rigidbody>().AddForce(0, 10, 0f, modo);
            }

            return objeto.transform.position;
        }

        public static UnityEngine.Vector3 SimplePlayerMovementCustomRB(GameObject objeto, KeyCode codeForward, KeyCode codeBackwards, KeyCode codeLeft, KeyCode codeRight)
        {
            if(Input.GetKey(codeForward))
            {
                objeto.transform.position += new UnityEngine.Vector3(0,0,0.1f);
            }

            if(Input.GetKey(codeBackwards))
            {
                objeto.transform.position += new UnityEngine.Vector3(0,0,-0.1f);
            }

            if(Input.GetKey(codeLeft))
            {
                objeto.transform.position += new UnityEngine.Vector3(-0.1f,0,0);
            }

            if(Input.GetKey(codeRight))
            {
                objeto.transform.position += new UnityEngine.Vector3(0.1f,0,0);
            }

            return objeto.transform.position;
        }

        public static void KeyCamMov(GameObject objeto, float rotationX, out float RotXOutPut, float topeRotacionArriba, float topeRotacionAbajo)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                objeto.transform.localEulerAngles += new UnityEngine.Vector3(0, 1, 0);    
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                objeto.transform.localEulerAngles += new UnityEngine.Vector3(0, -1, 0);    
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (rotationX > -topeRotacionArriba)
                {
                    rotationX -= 1;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                
                if (rotationX < -topeRotacionAbajo)
                {
                    rotationX += 1;
                }
            }

            RotXOutPut = rotationX; 
        }

        public static void KeyCamMov(GameObject objeto, float rotationX, out float RotXOutPut, float topeRotacionArriba, float topeRotacionAbajo, float velHor, float velVert)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                objeto.transform.localEulerAngles += new UnityEngine.Vector3(0, 1 * velHor, 0);    
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                objeto.transform.localEulerAngles += new UnityEngine.Vector3(0, -1 * velHor, 0);    
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (rotationX > -topeRotacionArriba)
                {
                    rotationX -= 1 * velVert;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                
                if (rotationX < -topeRotacionAbajo)
                {
                    rotationX += 1 * velVert;
                }
            }

            RotXOutPut = rotationX; 
        }

        
        public static void MouseCamMovFPS(GameObject objeto, float yRotation, float xRotation, Transform orientation ,out Transform orientationOut, out float yRotationOut, out float xRotationOut, float sensX, float sensY)
        {

            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            
            xRotation -= mouseY;

            Debug.Log($"{yRotation}, {xRotation}");
           
            xRotation = Math.Clamp(xRotation, -90f, 90f);

            objeto.transform.rotation = Quaternion.Euler(0, yRotation, 0);

            objeto.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(xRotation, 0, 0);

            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

            orientationOut = orientation;

            yRotationOut = yRotation;

            xRotationOut = xRotation;
                 
        }

        }

        public class BaseControls
        {
            public static bool Press(KeyCode tecla)
            {
                if (Input.GetKeyDown(tecla))
                {
                    return true;
                }
                else return false;
            }

            public static bool Maintain(KeyCode tecla)
            {
                if (Input.GetKey(tecla))
                {
                    return true;
                }
                else return false;
            }

            public static bool Release(KeyCode tecla)
            {
                if (Input.GetKeyUp(tecla))
                {
                    return true;
                }
                else return false; 
            }

            public static bool PMR(int accion, KeyCode tecla)
            {
                switch (accion)
                {
                    case 0:

                        if (Input.GetKeyDown(tecla))
                        {
                            return true;
                        }
                        else return false;

                    case 1:

                        if (Input.GetKey(tecla))
                        {
                            return true;
                        }
                        else return false;

                    case 2:

                        if (Input.GetKeyUp(tecla))
                        {
                            return true;
                        }
                        else return false;
                    
                    default:

                        break;
                }

                return false;
            }

            /*public static Vector2 MouseAxisDetector()
            {
                
            }*/
        }

        public class VRControls
        {/*
            public static Vector2 GetHeadSet()
            {
                
            }*/
        }
    }

    namespace Canvas
    {
        public class Cam
        {
            public static void ChangeCamInCanvas(List<GameObject> camaras, RawImage imagen, int numCamara)
            {
                
                imagen.texture = camaras[numCamara].GetComponent<Camera>().targetTexture;

            }

            public static IEnumerator RotateAmountByPress(GameObject objeto, KeyCode tecla, float cantidad, float segundosEntreMov)
            {

                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(tecla))
                    {
                        for(int i = 0; i < Mathf.Abs(cantidad); i++)
                        {

                            if (cantidad < 0)
                            {
                                objeto.transform.localEulerAngles += new UnityEngine.Vector3(-1,0,0);

                                yield return new WaitForSeconds(segundosEntreMov);
                            }

                            if (cantidad > 0)
                            {
                                objeto.transform.localEulerAngles += new UnityEngine.Vector3(1,0,0);

                                yield return new WaitForSeconds(segundosEntreMov);
                            }
                        }
                    }
                }
            }

            public static IEnumerator RotateAmountByPress(GameObject objeto, KeyCode tecla, float cantidad, float segundosEntreMov, bool setActive, bool setlate)
            {
                if (Input.anyKeyDown)
                {
                    Debug.Log("entrada input");

                    if (!setlate)
                    {
                        if (setActive)
                        {
                            objeto.gameObject.SetActive(true);
                        }

                        if (!setActive)
                        {
                            objeto.gameObject.SetActive(false);
                        }
                    }

                    if (Input.GetKeyDown(tecla))
                    {
                        Debug.Log("entrada input correcto");

                        if (cantidad < 0)
                        {
                            objeto.transform.Rotate(cantidad, 0, 0);

                            yield return new WaitForSeconds(segundosEntreMov);
                        }

                        if (cantidad > 0)
                        {
                            objeto.transform.Rotate(cantidad, 0, 0);

                            yield return new WaitForSeconds(segundosEntreMov);
                        }
                    }
                
                    if (setlate)
                    {

                        if (setActive)
                        {

                            Debug.Log("set Active true");
                            objeto.gameObject.SetActive(true);
                        }

                        if(!setActive)
                        {
                            Debug.Log("set Active false");
                            objeto.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    namespace Models
    {
        public class MatModf
        {

            public static void SimpleColorChange(GameObject objeto, float r, float g, float b,  float a)
            {
                objeto.GetComponent<Renderer>().material.color = new Color(r, g, b, a);
            }
            public static void SimpleAlphaChange(GameObject objeto, float valor)
            {
                objeto.GetComponent<Renderer>().material.color = new Color(objeto.GetComponent<Renderer>().material.color.r, objeto.GetComponent<Renderer>().material.color.g, objeto.GetComponent<Renderer>().material.color.b, valor);
            }

            public static void ColorChangeLerp(GameObject objeto, Color color1, Color color2)
            {
                objeto.GetComponent<Renderer>().material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1f));
            }

            public static void ColorAlphaChangeLerp(GameObject objeto, Color color1, Color color2, float alpha1, float alpha2)
            {
                objeto.GetComponent<Renderer>().material.color = Color.Lerp(new Color(color1.r, color1.g, color1.b, alpha1), new Color(color2.r, color2.g, color2.b, alpha2), Mathf.PingPong(Time.time, 1));
            }

            public static void CustomAlphaChange(GameObject objeto, float alpha, float tiempo)
            {
                objeto.GetComponent<Renderer>().material.color = new Color(objeto.GetComponent<Renderer>().material.color.r, objeto.GetComponent<Renderer>().material.color.g, objeto.GetComponent<Renderer>().material.color.b, alpha * (1 / tiempo) * Time.deltaTime);


        }
    }
  }

    namespace Logic
    {
        public class Func
        {
            /*public static void OneOrOtherFunc(List<IEnumerator> funciones, bool entrada, out bool salida)
            {
                GameObject eventHandler = GameObject.FindWithTag("EventHandler");

                Debug.Log("entrada OneorOther");

                if (entrada)
                {
                    Debug.Log("entrada OneorOther entrada");

                    eventHandler.GetComponent<CorrutineExecutor>().ExecuteCorrutine(funciones[0]);
                }

                if (!entrada)
                {
                    eventHandler.GetComponent<CorrutineExecutor>().ExecuteCorrutine(funciones[1]);
                }
                
                salida = !entrada;

            }*/
        }
    }

    namespace Logic
    {
        public class GUI
        {
            public static string PassFramesToText()
            {
                int fps;

                fps = (int)(1f/Time.unscaledDeltaTime);

                return fps.ToString();
            }
        }
    }

    namespace Logic
    {
        public class RayCasts
        {
            public static bool SimpleCast(GameObject objeto, Vector3 direccion, float longitud)
            {

                bool castHit = false;

                if (Physics.Raycast(objeto.transform.localPosition, direccion, longitud))
                {
                    castHit = true;
                }

                return castHit;
            }

            public static bool SimpleCastInfo(GameObject objeto, Vector3 direccion, float longitud, out RaycastHit castInfoOut)
            {

                RaycastHit castInfo;

                bool castHit = false;

                if (Physics.Raycast(objeto.transform.localPosition, direccion, out castInfo, longitud))
                {
                    castHit = true;
                }

                castInfoOut = castInfo;

                return castHit;
            }
 
            public static bool CustomCast(GameObject objeto, Vector3 direccion, Vector3 positionOffset, float longitud)
            {

                bool castHit = false;

                if (Physics.Raycast(objeto.transform.localPosition + positionOffset, direccion, longitud))
                {
                    castHit = true;
                }

                return castHit;
            }

            public static bool CustomCastInfo(GameObject objeto, Vector3 direccion, Vector3 positionOffset, bool automaticOffset, float longitud, out RaycastHit castInfoOut)
            {

                if (automaticOffset)
                {
                    positionOffset += objeto.transform.localScale/2;
                }

                RaycastHit castInfo;

                bool castHit = false;

                if (Physics.Raycast(objeto.transform.localPosition + positionOffset, direccion, out castInfo, longitud))
                {
                    castHit = true;
                }

                castInfoOut = castInfo;

                return castHit;
            }


        }
    }

    namespace GameMechanics
    {
        
    }
}
        