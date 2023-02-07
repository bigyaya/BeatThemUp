using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    AnimationCurve _jumpCurve;

    //[SerializeField]
    //float _jumpHeight = 3f;

    [SerializeField]
    float _jumpDuration = 3f;
    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _graphics = transform.Find("Graphics");
    }


    void Start()
    {
        
    }

    void Update()
    {
        if (_jumpTimer < _jumpDuration)
        {
            _jumpTimer += Time.deltaTime;

            float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);

            _graphics.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

        }
        else
        {
            _jumpTimer = 0f;
        }
        
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    Transform _graphics;
    float _jumpTimer;

    #endregion
}
