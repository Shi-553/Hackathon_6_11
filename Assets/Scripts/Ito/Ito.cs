using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class Ito : MonoBehaviour
{
    // 外部オブジェクト
    [field: SerializeField]
    public Transform StartPos
    {
        get;
        private set;
    }

    [field: SerializeField]
    public Transform EndPos
    {
        get;
        private set;
    }

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

    public float LengthPercent
    {
        get { return CurrentLength / MaxLength; }
    }

    // 内部パラメーター
    private float _beforeGrowthTime;
    private Vector3 _initScale;

    // 内部コンポーネント
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        TryGetComponent(out _spriteRenderer);
    }

    private void Start()
    {
        _beforeGrowthTime = Time.time;
        _initScale = transform.localScale;

        if (EndPos is null)
        {
            EndPos = new GameObject().transform;
            transform.position = StartPos.position + Vector3.down * MaxLength;
        }
        else
        {
            MaxLength = Mathf.Abs(EndPos.position.y - StartPos.position.y);
        }
        SetLength(0.0f);
    }

    private void Update()
    {
        if (Keyboard.current.anyKey.isPressed)
        {
            CutByPositionY(0.0f);
        }

        if (_beforeGrowthTime + Duration > Time.time)
            return;

        _beforeGrowthTime = Time.time;
        _initScale = transform.localScale;
        SetLength(CurrentLength + GrowthLength);
    }

    public void CutByPositionY(float y)
    {
        float length = StartPos.position.y - y;
        if (length < 0 || MaxLength < length)
            return;

        SetLength(length);
    }

    public void SetLength(float length)
    {
        if (length == CurrentLength)
            return;

        if (length > MaxLength)
            length = MaxLength;

        CurrentLength = length;
        transform.position = StartPos.position + Vector3.down * (length * 0.5f);
        transform.localScale = new Vector3(_initScale.x, length, _initScale.z);
    }
}
