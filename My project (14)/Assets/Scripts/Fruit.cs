using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject entero;
    public GameObject cortada;

    private Rigidbody fruitRigidBody;
    private Collider fruitCollider;
    private ParticleSystem juiceParticleEffect;

    private void Awake()
    {
        fruitRigidBody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        entero.SetActive(false);
        cortada.SetActive(true);

        fruitCollider.enabled = false;
        juiceParticleEffect.Play();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        cortada.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = cortada.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Slice blade = other.GetComponent<Slice>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }
}
