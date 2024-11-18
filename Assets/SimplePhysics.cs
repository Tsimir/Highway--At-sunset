using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePhysics : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        // �������� ��������� Rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // ��������� ��������� ����
        _rigidbody.AddForce(new Vector3(0, 0, 5), ForceMode.Force);
    }
}