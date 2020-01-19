using System;
using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;

public class ShapeSelecter : MonoBehaviour
{
    [SerializeField] private StringAction _shapeSelectionEvent;

    private void Start()
    {
        _shapeSelectionEvent.AddListener(SelectShape);
    }

    void SelectShape(string shape)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.Find(shape).gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _shapeSelectionEvent.RemoveListener(SelectShape);
    }
}
