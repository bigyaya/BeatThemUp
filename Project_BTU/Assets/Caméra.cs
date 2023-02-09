using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caméra : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    Transform _target;

    [SerializeField]
    [Range(0, 1)]
    float _lerpTime = 5f;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 targetPosition_zOffset = new Vector3(_target.position.x, _target.position.y, -10f);

        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition_zOffset, ref _velocity, _lerpTime * Time.deltaTime);

        //Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, _lerpTime * Time.fixedDeltaTime);

        transform.position = newPosition;
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected

    Vector3 _velocity;

    #endregion
}
