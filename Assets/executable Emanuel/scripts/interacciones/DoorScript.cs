using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{


    private bool abierta;
    int t = 0;
    private bool terminoAnimacion = true;

    void OnMouseDown()
    {
        if (terminoAnimacion == true)
        { 
            if (abierta == false)
            {
                abierta = true;
                terminoAnimacion = false;
                StartCoroutine("AbrirPuerta");  
            }
            else
            { 
                if (abierta == true)
                {
                    abierta = false;
                    terminoAnimacion = false;
                    StartCoroutine("CerrarPuerta");
                }
            }
        }


    }

    public IEnumerator AbrirPuerta()
    {
        t = 0;

        // si se quiere controlar en numero de grandos en el que se abre la puerta.... se cambia el valor de t en los while.
        while (t < 240f)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.0f);
            t++;
        }
        terminoAnimacion = true;

    }

    public IEnumerator CerrarPuerta()
    {
        t = 0;

        while (t < 240)
        {
            transform.Rotate(0, -1, 0);
            yield return new WaitForSeconds(0.0f);
            t++;
        }
        terminoAnimacion = true;

    }

}
