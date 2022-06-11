using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class Ito : MonoBehaviour
{
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

    public Vector3 StartPos
    {
        get;
        private set;
    }
    public Vector3 EndPos
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
    private List<GameObject> enemyList;
    public void AddEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void Cut()
    {
        float yPos = StartPos.y - MaxLength * LengthPercent;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].transform.position.y < yPos)
            {
                if (enemyList[i].GetComponent<BadEnemy>())
                {
                    enemyList[i].GetComponent<BadEnemy>().FallDown();
                }
                else if (enemyList[i].GetComponent<GoodEnemy>())
                {
                    enemyList[i].GetComponent<GoodEnemy>().FallDown();
                }
            }
        }
    }
    private void Awake()
    {
        TryGetComponent(out _spriteRenderer);
        enemyList = new List<GameObject>();
    }

    private void Start()
    {
        _beforeGrowthTime = Time.time;
        _initScale = transform.localScale;

        StartPos = transform.position;
        EndPos = transform.position + Vector3.down * MaxLength;
        SetLength(0.0f);
    }

    private void Update()
    {
        //if (Keyboard.current.anyKey.isPressed)
        //{
        //    CutByPositionY(0.0f);
        //}

        if (_beforeGrowthTime + Duration > Time.time)
            return;

        _beforeGrowthTime = Time.time;
        _initScale = transform.localScale;
        SetLength(CurrentLength + GrowthLength);
    }

    public void CutByPositionY(float y)
    {
        float length = StartPos.y - y;
        if (length < 0 || MaxLength < length)
            length = 0;

        SetLength(length);
        Cut();
    }

    public void SetLength(float length)
    {
        if (length == CurrentLength)
            return;

        if (length > MaxLength)
            length = MaxLength;

        CurrentLength = length;
        transform.position = StartPos + Vector3.down * (length * 0.5f);
        transform.localScale = new Vector3(_initScale.x, length, _initScale.z);
    }
}
