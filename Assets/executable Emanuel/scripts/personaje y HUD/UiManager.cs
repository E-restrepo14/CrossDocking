using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public GameObject flechasDeRotacion;
    public Image mouseSpriteH;
    public Image mouseSpriteV;
    public GameObject textManipulate;
    public GameObject textR;
    public GameObject textT;
    public GameObject textE;

    public static UiManager Instance;
    // este como varios otros singletons en la escena. almacenan variables que otros scripts toman y modifican para modificar las funciones de otros script que toman estas variables como argumentos
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
    //==================================================

   

    public void MostrarCosa(GameObject cosa)
    {
        cosa.SetActive(true);
    }
    public void OcultarCosa(GameObject cosa)
    {
        cosa.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("backup");
    }
}