using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    public static CameraController Instance;
    public float mouseSpeed = 2.0F;
    public Transform manoFalsa;
    [SerializeField]
    private Transform brazoFalso;

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

    


    void Update()
    {
        if (PlayerController.Instance.estaAcomodando == true)
        {
            UiManager.Instance.flechasDeRotacion.SetActive(PlayerController.Instance.estaAcomodando);
            UiManager.Instance.textT.SetActive(PlayerController.Instance.estaAcomodando);
            UiManager.Instance.textR.SetActive(PlayerController.Instance.estaAcomodando);
            UiManager.Instance.mouseSpriteH.enabled = false;
            UiManager.Instance.mouseSpriteV.enabled = false;

            if (Input.GetKey(KeyCode.X))
            {
                UiManager.Instance.mouseSpriteH.enabled = true;
                UiManager.Instance.flechasDeRotacion.SetActive(!PlayerController.Instance.estaAcomodando);
                float m = mouseSpeed * Input.GetAxis("Mouse X");
                manoFalsa.Rotate(m,0,0);

            }
            
            if (Input.GetKey(KeyCode.Y))
            {
                UiManager.Instance.mouseSpriteH.enabled = true;
                UiManager.Instance.flechasDeRotacion.SetActive(!PlayerController.Instance.estaAcomodando);
                float m = mouseSpeed * Input.GetAxis("Mouse X");
                manoFalsa.Rotate(0, m, 0);

            }
            
            if (Input.GetKey(KeyCode.Z))
            {
                UiManager.Instance.mouseSpriteH.enabled = true;
                UiManager.Instance.flechasDeRotacion.SetActive(!PlayerController.Instance.estaAcomodando);
                float m = mouseSpeed * Input.GetAxis("Mouse X");
                manoFalsa.Rotate(0, 0, m);
            }

            if (Input.GetKey(KeyCode.T))
            {
                UiManager.Instance.mouseSpriteV.enabled = true;
                UiManager.Instance.flechasDeRotacion.SetActive(!PlayerController.Instance.estaAcomodando);
                float y = mouseSpeed * Input.GetAxis("Mouse Y");
                brazoFalso.Translate(0, 0, y/100);
            }

        }

        if (PlayerController.Instance.estaAcomodando == false)
        {
            UiManager.Instance.flechasDeRotacion.SetActive(PlayerController.Instance.estaAcomodando);
            UiManager.Instance.textT.SetActive(PlayerController.Instance.estaAcomodando);

            float v = mouseSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(-v, 0, 0);
        }
        
    }

   

}
