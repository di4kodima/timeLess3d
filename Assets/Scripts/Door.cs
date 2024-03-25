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

    [Action("Осмотреть", true, 0)]
    public void Inspect()
    {
        Debug.Log("Осматриваю дверь");
    }

    [Action("Открыть",true, 2)]
    public void Open()  
    {
        Debug.Log("Открываю дверь");
    }
}
