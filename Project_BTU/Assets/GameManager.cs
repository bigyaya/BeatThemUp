using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    int _ennemiesCount;
    internal object _columnCount;
    internal object _linecount;
    internal int _lineCount;
    internal static object _grid;

    public object InitGrid { get; internal set; }

    #endregion

    #region Unity Lifecycle
    void Start()
    {

        _ennemiesCount = GameObject.FindGameObjectsWithTag("Ennemi").Length;
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods

    public void EnnemiesDecreament()
    {
        _ennemiesCount--;
        if (_ennemiesCount <= 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("Victoire");
    }

    public void Defeat()
    {
        Debug.Log("Defaite");
    }
    #endregion

    #region Private & Protected

    #endregion
}
