using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IController
{
    [SerializeField] Controls action;
    [SerializeField] PlayerFixedCamera cam;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject contexMenuPref;


    PlayerActor actor;
    InputAction MoveAction;
    GameObject ContextMenu;
    IInteracrive LastInteractive;
    private void Awake()
    {
        actor = GetComponent<PlayerActor>();
        action = new Controls();
    }
    void MouseMonitoring()
    {
        RaycastHit hit;
        if (!cam.Shoot(Mouse.current.position.ReadValue(), out hit))
        {
            LastInteractive?.ExitMouse();
            LastInteractive = null;
            return;
        }
        if (LastInteractive != hit.collider.gameObject.GetComponent<IInteracrive>())
        {
            LastInteractive?.ExitMouse();
        }
        if (hit.collider.gameObject.tag == "InteractiveObject")
        {
            if(Mouse.current.rightButton.ReadValue() != 0) 
            {
                Destroy(ContextMenu);
                ContextMenu = Instantiate(contexMenuPref, canvas.transform);
                (ContextMenu.GetComponent<Contex>())?.Activation(LastInteractive);
            }
            LastInteractive = hit.collider.gameObject.GetComponent<IInteracrive>();
            LastInteractive.MouseEnter();
        }
    }


    private void OnEnable()
    {
        MoveAction = action.Player.Move;
        MoveAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
    }

    private void FixedUpdate()
    {
        MouseMonitoring();
        if (MoveAction.ReadValue<Vector2>() != null && MoveAction.ReadValue<Vector2>() != Vector2.zero) {
            if(LastInteractive != null) 
                Destroy(ContextMenu);
            Vector2 moveInput = MoveAction.ReadValue<Vector2>();
            Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
            Quaternion rot = transform.rotation;
            rot = cam.transform.rotation;
            rot.z = 0;
            rot.x = 0;
            actor.transform.rotation = rot;
            actor?.Move(movement);
        }
    }
}
