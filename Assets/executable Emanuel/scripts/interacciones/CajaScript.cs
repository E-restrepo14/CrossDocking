using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaScript : MonoBehaviour
{
    public bool estaSosteniendo;
    public bool isSecure = true;
    public bool solto;
    public GameObject destinoFinal;
    public bool llegoAlDestino;

    public Text fechaDeEnvio;
    public Text lugarDeEnvio;
    public Text pesoDeCaja;

    [HideInInspector]
    public bool cuidoLasCajas = true;
    [HideInInspector]
    public bool almacenoPesoCorrecto;
    [HideInInspector]
    public bool almacenoFechaCorrecta;
    [HideInInspector]
    public bool envioFechaCorrecta;
    [HideInInspector]
    public bool envioLugarCorrecto;
    [HideInInspector]
    public bool recogioTodasLasCajas;

    string[] arrayCiudadesDestino = { "Cartagena", "Bogota", "Barranquilla", "Pereira", "Cucuta", "Valledupar" };

    // este script necesita tener un rigidbody pegado ne el inspector

    void Start()
    {
        cuidoLasCajas = true;
        StartCoroutine("EtiquetarCajas");
    }

    private IEnumerator EtiquetarCajas()
    {
        yield return new WaitForSeconds(5f);
        if (destinoFinal.GetComponent<FinalPointScript>().pesoEntrega != 0)
            pesoDeCaja.text = destinoFinal.GetComponent<FinalPointScript>().pesoEntrega + " kg";

        if (destinoFinal.GetComponent<FinalPointScript>().diaEntrega != 0 && destinoFinal.GetComponent<FinalPointScript>().mesEntrega != 0)
            fechaDeEnvio.text = destinoFinal.GetComponent<FinalPointScript>().diaEntrega + "/"+ destinoFinal.GetComponent<FinalPointScript>().mesEntrega + "/2018";

        if (destinoFinal.GetComponent<FinalPointScript>().lugarEntrega != (""))
            lugarDeEnvio.text = destinoFinal.GetComponent<FinalPointScript>().lugarEntrega;

        if (lugarDeEnvio.text == (""))
            lugarDeEnvio.text = arrayCiudadesDestino [Random.Range (0, arrayCiudadesDestino.Length)];
    }


    void OnMouseDown()
    {
        //cada vez que detecta el onmouse down, consulta al gamemanager si el jugador puede girar o no
        if (PlayerController.Instance.estaOcupado == false)
        {
            estaSosteniendo = true;
            GetComponent<Collider>().isTrigger = true;
            PlayerController.Instance.estaOcupado = true;
            UiManager.Instance.MostrarCosa(UiManager.Instance.textManipulate);
            UiManager.Instance.MostrarCosa(UiManager.Instance.textE);

        }


    }

    void Update()
    {
        if (estaSosteniendo == true)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            transform.position = CameraController.Instance.manoFalsa.transform.position;
            transform.rotation = CameraController.Instance.manoFalsa.transform.rotation;
            isSecure = true;


            if (solto == true)
            {
                estaSosteniendo = false;
                StartCoroutine("HaSidoSoltado");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                UiManager.Instance.textManipulate.SetActive(PlayerController.Instance.estaAcomodando);
                UiManager.Instance.textE.SetActive(PlayerController.Instance.estaAcomodando);
                PlayerController.Instance.estaAcomodando = !PlayerController.Instance.estaAcomodando;
                UiManager.Instance.textR.SetActive(PlayerController.Instance.estaAcomodando);
            }

        }

        

            if (PlayerController.Instance.estaAcomodando == false)
        {
            if (estaSosteniendo == true)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    solto = true;
                    UiManager.Instance.OcultarCosa(UiManager.Instance.textManipulate);
                    UiManager.Instance.OcultarCosa(UiManager.Instance.textE);
                }
            }
        }
    }

    public IEnumerator HaSidoSoltado()
    {
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        PlayerController.Instance.estaOcupado = false;
        isSecure = true;
        solto = false;
        yield return new WaitForSeconds(0.16f);
        isSecure = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinalTag") && other.gameObject.GetComponent<FinalPointScript>())
        {
            llegoAlDestino = true;
            almacenoPesoCorrecto = true;
            almacenoFechaCorrecta = true;
            envioFechaCorrecta = true;
            envioLugarCorrecto = true;
            recogioTodasLasCajas = true;


            if (other.gameObject.GetComponent<FinalPointScript>().diaEntrega != destinoFinal.GetComponent<FinalPointScript>().diaEntrega)
                llegoAlDestino = false;
                envioFechaCorrecta = false;


            //============================================

            if (other.gameObject.GetComponent<FinalPointScript>().mesEntrega != destinoFinal.GetComponent<FinalPointScript>().mesEntrega)
                llegoAlDestino = false;
                almacenoFechaCorrecta = false;


            //============================================

            if (other.gameObject.GetComponent<FinalPointScript>().lugarEntrega != destinoFinal.GetComponent<FinalPointScript>().lugarEntrega)
                llegoAlDestino = false;
                envioLugarCorrecto = false;


            //============================================

            if (other.gameObject.GetComponent<FinalPointScript>().pesoEntrega != destinoFinal.GetComponent<FinalPointScript>().pesoEntrega)
                llegoAlDestino = false;
                almacenoPesoCorrecto = false;
        }
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           

            if (isSecure == false)
            {
                print("golpeaste cajas");
                cuidoLasCajas = false;
            }

        }

    }

}
