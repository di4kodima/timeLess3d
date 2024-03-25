using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFixedCamera : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    Camera cam;

    [SerializeField] float angle_y = 0;
    [SerializeField] float angle_x = 0.75f;
    [SerializeField] float distance = 10;
    [SerializeField] float RotationSpeed = 0.05f;

    public float Distance
    {
        get => distance;
        set
        {
            if (value > 2)
            {
                distance = value;
            }
            else distance = 2;
        }
    }

    public float Angle_x { get => angle_x; set {
            if (value > 0.4f && value < 0.9f)
            {       
                angle_x = value;
                return;
            }
            if (value > 0.9f)
                angle_x = 0.9f;
            if (value < 0.4f)
                angle_x = 0.4f;
        }
    }
    public float Angle_y
    {
        get => angle_y; set
        {
            angle_y = value;
        }
    }

    public void Rotate(Vector2 vel)
    {
        Angle_x += vel.y * RotationSpeed;
        Angle_y += vel.x * RotationSpeed;
    }

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public Vector2 VectorToPlayer(Vector2 input)
    {
        input = input.normalized;
        Vector3 pos = new();
        pos.x = input.x * Mathf.Cos(angle_y) - input.y * Mathf.Sin(angle_y);
        pos.y = input.y * Mathf.Sin(angle_y) + input.y * Mathf.Cos(angle_y);
        return pos;
    }

   public void UpdatePos()
    {
        float d = Mathf.Acos(angle_x) * distance;
        float h = Mathf.Asin(angle_x) * distance;

        Vector3 pos = new Vector3(Mathf.Cos(angle_y) * d, h, Mathf.Sin(angle_y) * d);
        transform.localPosition = target.transform.position + pos;
    }

    public bool Shoot(Vector2 pos, out RaycastHit hit)
    {
        Ray ray = cam.ScreenPointToRay(pos);
        return Physics.Raycast(ray, out hit);
    }

    void Update()
    {
        UpdatePos();
        transform.LookAt(target.transform.position);
    }
}
