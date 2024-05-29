using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> _mousePositionList;

    [SerializeField] private Slider _slider;


    void Awake()
    {
        _mousePositionList = new List<Vector3>();
        _lineRenderer = GetComponent<LineRenderer>();

        SetDefaultProperties();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            if (_mousePositionList.Count == 0 || Vector3.Distance(_mousePositionList[^1], mousePosition) > 0.1f)
            {
                _mousePositionList.Add(mousePosition);
                _lineRenderer.positionCount = _mousePositionList.Count;
                _lineRenderer.SetPosition(_mousePositionList.Count - 1, mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _mousePositionList.Clear();
            _lineRenderer.positionCount = 0;
        }
    }

    private void SetDefaultProperties()
    {
        _lineRenderer.startColor = Color.white;
        _lineRenderer.endColor = Color.white;
        _lineRenderer.positionCount = 0;
        _lineRenderer.startWidth = 0.5f;
        _lineRenderer.endWidth = 0.5f;
        _slider.value = _lineRenderer.startWidth;
    }

    public void SetWidth()
    {
        _lineRenderer.startWidth = _slider.value;
        _lineRenderer.endWidth = _slider.value;
    }
}