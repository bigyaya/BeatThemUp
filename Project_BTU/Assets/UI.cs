using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    #region Exposed

    [SerializeField] private Caméra _simulation;

    [SerializeField] private GameManager _grid;

    [SerializeField] private SliderJoint2D _lineCountSlider;

    [SerializeField] private TextMeshProUGUI _lineCountText;

    [SerializeField] private SliderJoint2D _columnCountSlider;

    [SerializeField] private TextMeshProUGUI _columnCountText;

    #endregion

    #region Unity Lifecycle
    private void Start()
    {

        //_lineCountSlider.value = _grid._linecount;
        //_columnCountSlider.value = _grid._columnCount;
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods

    public void OnAutoPlayTogled(bool value)
    {
        _simulation._isPlaying = value;
    }

    public void OnLineCountChanged( float value)
    {
        _lineCountText.text = ((int)value).ToString();
        _grid._lineCount = (int)value;
    }


    public void OnColumnCountChanged(float value)
    {
        _columnCountText.text = ((int)value).ToString();
        _grid._columnCount = (int)value;

    }

    public void OnGenerateGrid()
    {
     //   _grid.(InitGrid);
    }

    #endregion

    #region Private & Protected

    #endregion
}
