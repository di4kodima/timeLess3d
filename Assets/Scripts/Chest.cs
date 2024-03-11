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

    [Action("Осмотреть", true, 0)]
    public void inspect()
    {
        Debug.Log("Меня хотят осмотреть");
    }
    [Action("Открыть",false, 5)]
    public void Open()
    {
        Debug.Log("Меня хотят открыть");
    }
}
