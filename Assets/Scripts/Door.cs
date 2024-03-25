using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteracrive
{
    MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    public void ExitMouse()
    {
        mr.material.color = Color.red;
    }
    public void MouseEnter()
    {
        mr.material.color = Color.gray;
    }

    [Action("���������", true, 0)]
    public void Inspect()
    {
        Debug.Log("���������� �����");
    }

    [Action("�������",true, 2)]
    public void Open()  
    {
        Debug.Log("�������� �����");
    }
}
