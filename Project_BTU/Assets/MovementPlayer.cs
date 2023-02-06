using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


enum PlayerStateMode
{
    LOCOMOTION,
    ROLL,
    SPRINT
}
public class MovementPlayer : MonoBehaviour
{
    #region Exposed
    [Header("Timer Parameters")]
    [SerializeField]
    private float _rollDuration = 0.5f;

    [Header("Moving Parameer")]
    [SerializeField]
    private float _runSpeed = 2f;

    [SerializeField]
    private float _sprintSpeed = 3f;

    [SerializeField]
    private AnimationCurve _rollCurve;

    [SerializeField]
    private float _rollSpeedMultiplier = 100f;

    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        TransitionToState(PlayerStateMode.LOCOMOTION);
    }

    private void Update()
    {
        OnStateUpdate();
        SetInput();
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _direction.normalized * _currentSpeed * Time.fixedDeltaTime;
    }
    #endregion

    #region Methods

    void OnStateEnter()
    {
        switch (_currentState)
        {
            case PlayerStateMode.LOCOMOTION:
                break;
                case PlayerStateMode.ROLL:
                _animator.SetBool("isRolling", true);
                _endRollTime = Time.timeSinceLevelLoad + _rollDuration;
                break;
            case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", true);
                break;
        }
    }

    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case PlayerStateMode.LOCOMOTION:
                _currentSpeed = _runSpeed;
                _animator.SetFloat("DirectionX", _direction.x);
                _animator.SetFloat("DirectionY", _direction.y);

                if (Input.GetButtonDown("Fire3"))
                {
                    TransitionToState(PlayerStateMode.ROLL);
                }
                break;
            case PlayerStateMode.ROLL:
                _rollCount += Time.deltaTime;
                _rollSpeed = _rollCurve.Evaluate(_rollCount / _rollDuration) * _rollSpeedMultiplier;
                _currentSpeed = _rollSpeed;

                if (Time.timeSinceLevelLoad > _endRollTime)
                {
                    if (Input.GetButton("Fire3"))
                    {
                        TransitionToState(PlayerStateMode.SPRINT);
                    }
                    else
                    {
                        TransitionToState(PlayerStateMode.LOCOMOTION);
                    }
                }

                break;
                case PlayerStateMode.SPRINT:
                _currentSpeed = _sprintSpeed;
                _animator.SetFloat("DirectionX", _direction.x);
                _animator.SetFloat("DirectionY", _direction.y);
                if (Input.GetButtonUp("Fire3"))
                {
                    TransitionToState(PlayerStateMode.LOCOMOTION);
                }
                break;
            default:
                break;
        }
    }
    void OnStateExit()
    {
        switch (_currentState)
        {
            case PlayerStateMode.LOCOMOTION:
                break;
            case PlayerStateMode.ROLL:
                _animator.SetBool("isRolling", false);
                _rollCount = 0f;

                break;
                case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", false);
                break;
            default:
                break;
        }
    }
    void TransitionToState(PlayerStateMode toState)
    {
        OnStateExit();
        _currentState = toState;
        OnStateEnter();
    }

    void SetInput()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");
    }
    #endregion

    #region Private & Protected


    private PlayerStateMode _currentState;
    private Animator _animator;
    private float _endRollTime;


    private Rigidbody2D _rb2d;
    private Vector2 _direction;
    private float _currentSpeed;
    private float _rollCount = 0f;
    private float _rollSpeed;

    #endregion
}
