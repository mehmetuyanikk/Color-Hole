using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public static Magnet Instance;

    [SerializeField] float _magnetForce;

    List<Rigidbody> _affectedRigidBodies = new List<Rigidbody>();
    Transform _magnet;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _magnet = transform;
        _affectedRigidBodies.Clear();
    }

    private void FixedUpdate()
    {
        if (!Game.isGameOver && Game.isMoving)
        {
            foreach (Rigidbody rb in _affectedRigidBodies)
            {
                rb.AddForce((_magnet.position - rb.position) * _magnetForce * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameOver && (other.gameObject.CompareTag("article")) || (other.gameObject.CompareTag("obsticle")))
        {
            AddToMagnetField(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Game.isGameOver && (other.gameObject.CompareTag("article")) || (other.gameObject.CompareTag("obsticle")))
        {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddToMagnetField(Rigidbody rb)
    {
        _affectedRigidBodies.Add(rb);
    }

    public void RemoveFromMagnetField(Rigidbody rb)
    {
        _affectedRigidBodies.Remove(rb);
    }

}
