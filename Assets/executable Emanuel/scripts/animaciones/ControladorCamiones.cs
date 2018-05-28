using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamiones : MonoBehaviour
{
    private bool desacelero;
    int t = 0;


    void Awake()
    {
        StartCoroutine("PedirOtroCamion");
        
    }

  

    public IEnumerator PedirOtroCamion()
    {
        t = 0;

        // si se quiere controlar en numero de grandos en el que se abre la puerta.... se cambia el valor de t en los while.
        while (t < 500)
        {
            transform.Translate(0, 0, 0.5f);
            yield return new WaitForSeconds(0.0f);
            t++;
        }
        
        t = 0;

        while (t < 400)
        {
            transform.Translate(0, 0, -0.5f);
            yield return new WaitForSeconds(0.0f);
            t++;
        }

        t = 0;

        while (t < 150)
        {
            transform.Translate(0, 0, -0.25f);
            yield return new WaitForSeconds(0.0f);
            t++;
        }
        t = 0;

        while (t < 100)
        {
            transform.Translate(0, 0, -0.125f);
            yield return new WaitForSeconds(0.0f);
            t++;
        }

    }

}
	

