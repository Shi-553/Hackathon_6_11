using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputManager : MonoBehaviour
{
    private InputActionData _input;

    public Vector2 Move
    {
        get { return _input.Player.Move.ReadValue<Vector2>(); }
    }
    public Vector2 Look
    {
        get { return _input.Player.Look.ReadValue<Vector2>(); }
    }
    public bool Fire
    {
        get { return _input.Player.Fire.triggered; }
    }

    void Start()
    {
        _input = new InputActionData();
        _input.Player.Move.performed += MoveOnperformed;
        _input.Player.Look.performed += LookOnperformed;
        _input.Player.Fire.performed += FireOnperformed;
    }

    private void FireOnperformed(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void LookOnperformed(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void MoveOnperformed(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
}
