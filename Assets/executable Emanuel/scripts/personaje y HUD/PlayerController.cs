using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

public static PlayerController Instance;

	private void Awake()
	{
		if (Instance == null) 
		{
			Instance = this;
		} 
		else 
		{
			Destroy (this);
		}
	}

    public float speed = 10.0F;
    public float horizontalSpeed = 2.0F;

    public bool estaOcupado;
    public bool estaAcomodando;

    void Update() 
	{
        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
         float horizontaltranslation = Input.GetAxis("Horizontal") * speed;
        horizontaltranslation *= Time.deltaTime;
        transform.Translate(horizontaltranslation, 0, translation);
        
		if (estaAcomodando == false)
        { 
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, h, 0);
        }
    }
}
