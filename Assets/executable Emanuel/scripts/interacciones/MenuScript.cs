using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{


    private bool abierto = true;
    int t = 0;
    private bool terminoAnimacion = true;

    public void Activar()
    {
        if (terminoAnimacion == true)
        {
            if (abierto == false)
            {
                abierto = true;
                terminoAnimacion = false;
                StartCoroutine("AbrirMenu");
            }
            else
            {
                if (abierto == true)
                {
                    abierto = false;
                    terminoAnimacion = false;
                    StartCoroutine("CerrarMenu");
                }
            }
        }
    }
        public IEnumerator AbrirMenu()
        {
            t = 0;

            // si se quiere controlar en numero de grandos en el que se abre la puerta.... se cambia el valor de t en los while.
            while (t < 240f)
            {
                transform.Translate(-2,0,0);
                yield return new WaitForSeconds(0.0f);
                t++;
            }
            terminoAnimacion = true;

        }

        public IEnumerator CerrarMenu()
        {
            t = 0;

            while (t < 240)
            {
                transform.Translate(2,0,0);
                yield return new WaitForSeconds(0.0f);
                t++;
            }
            terminoAnimacion = true;

        }

}

