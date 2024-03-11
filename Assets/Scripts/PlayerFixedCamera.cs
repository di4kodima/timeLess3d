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
