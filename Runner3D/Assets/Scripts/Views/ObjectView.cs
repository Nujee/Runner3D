using System;
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

    public Action<ObjectView> OnContact { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectView temp = collision.gameObject.GetComponent<ObjectView>();
        OnContact?.Invoke(temp);
    }
}
