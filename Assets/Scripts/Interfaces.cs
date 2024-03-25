using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
public class Interfaces : MonoBehaviour
{
}

public interface IActor
{
    public void Move(Vector3 vel);                         //Передвижение в направлении
    public void MoveTo(GameObject target, Action action);  //Для  навигации, приказ идти к объекту и вызвать метод
    public void MoveTo(Vector3 pos);        //Для  навигации, приказ идти в опр. точку
}

public interface IController
{
}
public interface IInteracrive
{
    /// <summary>
    /// Когда на него наведена мышь
    /// </summary>
    public void MouseEnter();
    public void ExitMouse();
}

public class ActionAttribute : Attribute
{
    public string Name;
    public bool Acess;
    public float time;
    public ActionAttribute(string name, bool acess, float time)
    {
        Name = name;
        Acess = acess;
        this.time = time;
    }
}


