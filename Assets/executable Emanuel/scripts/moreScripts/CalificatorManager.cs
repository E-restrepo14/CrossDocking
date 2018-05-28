using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalificatorManager : MonoBehaviour
{
    public GameObject[] cajasListas;    

    public Text respuesta1;
    public Text respuesta2;
    public Text respuesta3;
    public Text respuesta4;
    public Text respuesta5;
    public Text respuesta6;
    public Text timerText;

    private string tiempoTranscurrido;

    public static CalificatorManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }


    }
  


    public void Calificar()
    {


        cajasListas = (GameObject.FindGameObjectsWithTag("CajaLista"));

        foreach (GameObject cajasola in cajasListas)
        {
            if (cajasola.GetComponent<CajaScript>().cuidoLasCajas == false)
                respuesta1.text = "no";

            if (cajasola.GetComponent<CajaScript>().almacenoPesoCorrecto == false)
                respuesta2.text = "no";

            if (cajasola.GetComponent<CajaScript>().almacenoFechaCorrecta == false)
                respuesta3.text = "no";

            if (cajasola.GetComponent<CajaScript>().envioFechaCorrecta == false)
                respuesta4.text = "no";

            if (cajasola.GetComponent<CajaScript>().envioLugarCorrecto == false)
                respuesta5.text = "no";

            if (cajasola.GetComponent<CajaScript>().recogioTodasLasCajas == false)
                respuesta6.text = "no";
        }

        timerText.text = (Time.fixedTime.ToString("f0") + " segundos");
    }
}
