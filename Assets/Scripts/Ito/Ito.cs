using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class Ito : MonoBehaviour
{
    // イベント
    UnityEvent OnCuttedEvent;

    // 外部オブジェクト
    public Transform Origin;

    // 外部パラメーター
    [field: SerializeField]
    public float MaxLength
    {
        get;
        private set;
    }
    [field: SerializeField]
    public float CurrentLength
    {
        get;
        private set;
    }
    [field: SerializeField]
    public float Duration
    {
        get;
        private set;
    }
    [field: SerializeField]
    public float GrowthLength
    {
        get;
        private set;
    }

    // 内部パラメーター
    private float _pixelsPerUnit;
    private float _beforeGrowthTime;

    // 内部コンポーネント
    private SpriteRenderer _spriteRenderer;
    private Sprite _sprite;

    void Awake()
    {
        TryGetComponent(out _spriteRenderer);
        _sprite = _spriteRenderer.sprite;
        _pixelsPerUnit = _sprite.pixelsPerUnit;
    }

    void Start()
    {
        OnCuttedEvent = new UnityEvent();

        _beforeGrowthTime = Time.time;
    }

    void Update()
    {
        if (Keyboard.current.anyKey.isPressed)
        {
            CutByPositionY(0.0f);
        }

        if (_beforeGrowthTime + Duration > Time.time)
            return;

        _beforeGrowthTime = Time.time;
        SetLength(CurrentLength + GrowthLength);
    }

    void CutByPositionY(float y)
    {
        float length = Origin.position.y - y;
        //if (length < 0 || MaxLength < length)
        //    return;

        SetLength(length);
    }

    void SetLength(float length)
    {
        if (length == CurrentLength)
            return;

        if (length > MaxLength)
            length = MaxLength;

        CurrentLength = length;
        transform.position = Origin.position + Vector3.down * (length * 0.5f);
        transform.localScale = new Vector3(1.0f, length, 1.0f);
    }
}
