using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteracrive
{
    MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    public void MouseEnter()
    {
        mr.materials[0].color = Color.white;
    }

    public void ExitMouse() 
    {
        mr.materials[0].color = Color.red;
    }

    [Action("���������", true, 0)]
    public void inspect()
    {
        Debug.Log("���� ����� ���������");
    }
    [Action("��������", false, 123)]
    public void Loot()
    {
        Debug.Log("���� ����� ��������");
    }
}
