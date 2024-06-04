using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider areaSpawn;

    public GameObject[] prehabsFrutas;

    //Tiempo de tardado de aparicion de frutas
    public float delaySpawnMinimo = 0.25f;
    public float delaySpawnMaximo = 1f;

    //Angulos de lanzado de frutas
    public float anguloMinimo = -15f;
    public float anguloMaximo = 15f;

    //Fuerza de lanzado de frutas
    public float fuerzalanzadoMinima = 18f;
    public float fuerzaLanzadoMaxima = 22f;

    //Tiempo maximo de duracion de fruta en pantalla
    public float tiempoMaximoVidaFruta = 5f;

    private void Awake()
    {
        areaSpawn = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable() 
    {
        StopAllCoroutines();
    }

    private IEnumator Spawn()
    {
        
    }
}
