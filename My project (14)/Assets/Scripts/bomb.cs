using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bomb : MonoBehaviour
{
    private Rigidbody fruitRigidBody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticleEffect;

    private void Awake()
    {
        fruitRigidBody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
