using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    #region Exposed

    #endregion

	

    #region Unity Lifecycle
void Awake()
{

}

 void Start()
    {

    }

 void Update()
    {

    }

void FixedUpdate()
{

}
    #endregion



    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddRecords(1);
            Destroy(gameObject);
        }
    }

    #endregion



    #region Private & Protected

    #endregion
}
