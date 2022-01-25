using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
    public Transform _transform;
    public Collider _collider;
    public Rigidbody _rigidbody;

    private void Awake()
    {
        if (gameObject.GetComponent<Transform>())
            _transform = gameObject.GetComponent<Transform>();

        if (gameObject.GetComponent<Collider>())
            _collider = gameObject.GetComponent<Collider>();

        if (gameObject.GetComponent<Rigidbody>())
            _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
}
