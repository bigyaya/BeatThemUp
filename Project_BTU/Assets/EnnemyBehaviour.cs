using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IDLE,
    WALK,
    ATTACK,
    DEAD
}

public class EnnemyBehaviour : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _limitNearTarget = 0.5f;

    [SerializeField]
    private float _waitingTimeBeforeAttack = 1f;

    [SerializeField]
    private float _attackDuration = 0.2f;

    [SerializeField]
    private GameObject _hitbox;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        TransitionToState(EnemyState.IDLE);
        _moveTarget = GameObject.Find("Player").transform;
    }

    void Update()
    {
        OnStateUpdate();
    }
    #endregion

    #region Methods

    void OnStateEnter()
    {
        switch( _currentState )
        {
            case EnemyState.IDLE:
                _attackTimer = 0f;
                break;
            case EnemyState.WALK:
                _animator.SetBool("isWalking", true);
                break;
            case EnemyState.ATTACK:
                _attackTimer = 0f;
                _hitbox.SetActive(true);
                _animator.SetBool("isAttacking", true);
                break;
            case EnemyState.DEAD:
                break;
            default:
                break;
        }
    }

    void OnStateUpdate()
    {
        switch( _currentState)
        {
            case EnemyState.IDLE:

                if ( _playerDetected && IsTargetNearLimit())
                {
                    TransitionToState(EnemyState.WALK);
                }

                if ( IsTargetNearLimit())
                {
                    _attackTimer += Time.deltaTime;
                    if ( _attackTimer >= _waitingTimeBeforeAttack )
                    {
                        TransitionToState(EnemyState.ATTACK);
                    }
                }

                break;
            case EnemyState.WALK:

                transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, Time.deltaTime );

                if (IsTargetNearLimit())
                {
                    TransitionToState(EnemyState.IDLE);
                }


                if (!_playerDetected)
                {
                    TransitionToState(EnemyState.IDLE);
                }

                break;
            case EnemyState.ATTACK:

                _attackTimer += Time.deltaTime;
                if ( _attackTimer >= _attackDuration)
                {
                    TransitionToState(EnemyState.IDLE);
                }
                break;
            case EnemyState.DEAD:
                break;
            default:
                break;
        }
    }

    void OnStateExit()
    {
        switch( _currentState )
        {
            case EnemyState.IDLE:
                break;
            case EnemyState.WALK:
                _animator.SetBool("isWalking", false);
                break;
            case EnemyState.ATTACK:
                _hitbox.SetActive(false);
                _animator.SetBool("isWalking", false);
                break;
            case EnemyState.DEAD:
                break;
            default:
                break;
        }
    }

    void TransitionToState( EnemyState nextState )
    {
        OnStateExit();
        _currentState = nextState;
        OnStateEnter();
    }

    void PlayerDetected()
    {
        
        _playerDetected = true;
    }

    void PlayerEscaped()
    {
        _playerDetected = false;
    }

    bool IsTargetNearLimit()
    {
        return Vector2.Distance(transform.position, _moveTarget.position) < _limitNearTarget;
    }

    #endregion

    #region Private & Protected

    private EnemyState _currentState;
    private bool _playerDetected = false;
    private Transform _moveTarget;
    private float _attackTimer;

    #endregion
}
