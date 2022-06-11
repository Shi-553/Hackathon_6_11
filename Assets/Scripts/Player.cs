using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class Player : MonoBehaviour
{
    private PlayerInputManager _input;
    Vector3 beforePos;

    [SerializeField]
    LayerMask itoLayer;

    SpriteRenderer spriteRenderer;
    Animator animator;
    void Start()
    {
        TryGetComponent(out _input);
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out animator);

        Cursor.visible = false;
        animator.enabled = true;
        animator.speed = 0;
    }
    void OnDestroy()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animator.speed = 1;
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            animator.speed = 0;

        }

        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (beforePos == touchWorldPosition)
            return;

        // 位置設定と左右反転
        var playerPos = touchWorldPosition;
        playerPos.z = 0;
        transform.position = playerPos;
        spriteRenderer.flipX = beforePos.x > touchWorldPosition.x;



        if (Mouse.current.leftButton.isPressed)
        {
            Linecast(beforePos, touchWorldPosition);
        }

        beforePos = touchWorldPosition;
    }

    void Linecast(Vector3 before, Vector3 after)
    {
        var hits = Physics2D.LinecastAll(before, after, itoLayer);

        foreach (var hit in hits)
        {
            hit.transform.TryGetComponent<Ito>(out var ito);

            ito.CutByPositionY(hit.point.y);
        }
    }
}
