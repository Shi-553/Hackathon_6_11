using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class Player : MonoBehaviour
{
    private PlayerInputManager _input;

    void Start()
    {
        TryGetComponent(out _input);
    }

    void Update()
    {
        _ = _input.Move.x;
        _ = _input.Move.y;
    }
}
