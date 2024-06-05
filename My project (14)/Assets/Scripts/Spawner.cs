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

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = prehabsFrutas[Random.Range(0, prehabsFrutas.Length)];
            Vector3 posicion = new Vector3();

            posicion.x = Random.Range(areaSpawn.bounds.min.x, areaSpawn.bounds.max.x);
            posicion.y = Random.Range(areaSpawn.bounds.min.y, areaSpawn.bounds.max.y);
            posicion.z = Random.Range(areaSpawn.bounds.min.z, areaSpawn.bounds.max.z);

            Quaternion rotacion = Quaternion.Euler(0f, 0f, Random.Range(anguloMinimo, anguloMaximo));
            GameObject fruta = Instantiate(prefab, posicion, rotacion);
            Destroy(fruta, tiempoMaximoVidaFruta);

            float fuerza = Random.Range(fuerzalanzadoMinima, fuerzaLanzadoMaxima);
            fruta.GetComponent<Rigidbody>().AddForce(fruta.transform.up * fuerza, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(delaySpawnMinimo, delaySpawnMaximo));
        }
    }
}