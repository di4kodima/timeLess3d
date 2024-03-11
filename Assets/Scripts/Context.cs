using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditor.Profiling.FrameDataView;

public class Contex : MonoBehaviour
{
    [SerializeField]Canvas canvas;
    [SerializeField] UnityEngine.UI.Button buttonPref;

    private void Start()
    {
        transform.position = (Vector3)Mouse.current.position.value;
    }

    public  void Activation(IInteracrive interacrive)
    {
        Type type = interacrive.GetType();
        object[] atributes = type.GetCustomAttributes(false);
        System.Reflection.MethodInfo[] methods = interacrive.GetType().GetMethods()
            .Where(m => m.GetCustomAttributes(typeof(ActionAttribute), false).Any())
            .ToArray();
        foreach (var method in methods) 
        {
            canvas.transform.localScale = new Vector3(1,1*methods.Length,1);
            UnityEngine.UI.Button button = Instantiate(buttonPref, canvas.transform);
            button.onClick.AddListener(() => method.Invoke(interacrive,null) );
            ActionAttribute attribute = (ActionAttribute) method.GetCustomAttribute(typeof(ActionAttribute), false);
            button.GetComponentInChildren<TMP_Text>().text = attribute.Name;
        }
    }
}
