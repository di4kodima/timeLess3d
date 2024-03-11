using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Reflection;

public class Co : MonoBehaviour
{
    [SerializeField]Canvas canvas;
    public  void Scan(Chest interacrive)
    {
        Type type = interacrive.GetType();
        object[] atributes = type.GetCustomAttributes(false);
        MethodInfo[] methods = interacrive.GetType().GetMethods()
            .Where(m => m.GetCustomAttributes(typeof(ActionAttribute), false).Any())
            .ToArray();

        foreach (var method in methods)
        {
            Debug.Log($"Метод: {method.Name}");


            var attributes = method.GetCustomAttributes(typeof(ActionAttribute), false);
            foreach (var attribute in attributes)
            {
                Debug.Log($"Атрибут: {((ActionAttribute)attribute).Name}");
            }
        }
    }
}
