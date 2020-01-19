using System;
using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;
using Zenject;

public class ShapeSelecter : MonoBehaviour
{
    [SerializeField] private StringAction _shapeSelectionEvent;
    
    private IUndoRedoHandler _undoRedoHandler;

    [Inject]
    public void Construct(IUndoRedoHandler undoRedoHandler)
    {
        _undoRedoHandler = undoRedoHandler;
    }
    
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
        _undoRedoHandler.ResetHistory();
    }

    private void OnDestroy()
    {
        _shapeSelectionEvent.RemoveListener(SelectShape);
    }
}
