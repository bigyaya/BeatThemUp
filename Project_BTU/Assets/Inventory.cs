using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Exposed

    public int recordsCount;
    public Text recordsCountText;

    public static Inventory instance;

    #endregion

	

    #region Unity Lifecycle
void Awake()
{
        if (instance != null)
        {

        }
        instance = this;
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

    public void AddRecords(int count)
    {
        recordsCount += count;
        recordsCountText.text = recordsCount.ToString();
    }

    #endregion



    #region Private & Protected

    #endregion
}
