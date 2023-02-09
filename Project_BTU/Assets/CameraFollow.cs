using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Exposed

    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed = 15f;

    #endregion



    #region Unity Lifecycle
    void Start()
    {

    }

    private void LateUpdate()
    {
       

       // Vector3 playerPosition_zOffset = new Vector3(_target.position.x, _target.position.y, -10f);
        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, _cameraSpeed * Time.deltaTime);
        newPosition.z = -10;
        transform.position = newPosition;
    }
    #endregion



    #region Methods

    #endregion



    #region Private & Protected

    #endregion
}
