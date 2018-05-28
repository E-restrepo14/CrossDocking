using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour 
{

 /* este mejor se llamará box.
    Box, cuando se les de la orden de "calificar el test"... mirarán si estan bien guardadas en sus "destinationPoints"... 
    y si no....ponen la queja al "LevelManager" para que el jugador pierda puntos.
    (tambien cada vez que sean "soltadas" por el jugador verificaran si este las dejó caer o no, y en caso de que lo 
    hiciera, ponerle la queja al "LevelManager") */

    public GameObject[] spawnPointsPrefabs;
    public GameObject[] destinosFinalesArray;
    public List<GameObject> destinosFinalesList;
    public GameObject boxPrefabGO;
    public GameObject CajaTemporal;
    public GameObject emptyprefab;


    private void Start()
    {
        SelectDestinoFinal();
    }

    public void SelectDestinoFinal()
    {
        // se guardo en un array todos los spawns (los emptys de los camiones grandes) y por cada uno de ellos se instancia un prefab de caja

        //                                          ==================((((importantisimo al hacerlo... desde acá asignarle "la meta" a la caja))))==============================

        destinosFinalesArray = (GameObject.FindGameObjectsWithTag("FinalTag"));

        foreach (GameObject metas in destinosFinalesArray)
        {
            destinosFinalesList.Add(metas);
        }

        SelectSpawns();
    }

    public void SelectSpawns()
    {
        // se guardo en un array todos los spawns (los emptys de los camiones grandes) y por cada uno de ellos se instancia un prefab de caja

        //                                          ==================((((importantisimo al hacerlo... desde acá asignarle "la meta" a la caja))))==============================

        spawnPointsPrefabs = (GameObject.FindGameObjectsWithTag("SpawnTag"));



        //talvez debería pensar si evitar que se instancien mas cajas de las que se pueden almacenar en la escena.    solo talvez
        foreach (GameObject spawntransform in spawnPointsPrefabs)
        {
            int i = Random.Range(1, 6);
            // con este random y este if se van a instanciar cajas solo en algunos (no todos los) spawnpoints dentro de los camiones grandes... 
            if (i == 1)
            {
                CajaTemporal = Instantiate(boxPrefabGO, spawntransform.transform.position, spawntransform.transform.rotation);
                asignarMeta(CajaTemporal);
            }
        }
    }
    //     https://www.dotnetperls.com/convert-list-array     por cierto este script se encuentra en el empty lleno de cajas literalmente guiño guiño



    public void asignarMeta(GameObject CajaTemporal)
    {

        int i = Random.Range(0, destinosFinalesList.Count);

        CajaTemporal.GetComponent<CajaScript>().destinoFinal = destinosFinalesArray[i];
        // como varias cajas pueden caber en un mismo estante no hace falta remover el destino final de "destinosFinalesList"
    }

}
