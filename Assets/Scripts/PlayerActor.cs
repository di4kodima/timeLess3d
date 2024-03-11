using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActor : MonoBehaviour, IActor
{
    [SerializeField]
    float Speed = 20;
    [SerializeField]
    GameObject model;

    CharacterController contr;

    private void Awake()
    {
        contr = gameObject.GetComponent<CharacterController>();
    }

    public void Move(Vector3 vel)
    {
        contr.SimpleMove(transform.TransformDirection(vel.normalized)* Speed);
    }

    private void FixedUpdate()
    {
        contr.SimpleMove(Vector3.zero);
    }

    public void MoveTo(Vector3 pos)
    {
        throw new NotImplementedException();
    }
    public void MoveTo(GameObject target, Action action)
    {
        throw new NotImplementedException();
    }
}
