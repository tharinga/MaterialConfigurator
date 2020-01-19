using System;
using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;

public class SelectionCircle : MonoBehaviour
{
    [SerializeField] private GameObject _selectionCircle;
    [SerializeField] private VoidAction _objectSelectionEvent;
    
    private void Start()
    {
        _objectSelectionEvent.AddListener(Hide);
        Hide();
    }

    private void Hide()
    {
        _selectionCircle.SetActive(false);
    }

    public void Show()
    {
        _objectSelectionEvent.Invoke();
        _selectionCircle.SetActive(true);
    }

    private void OnDestroy()
    {
        _objectSelectionEvent.RemoveListener(Hide);
    }
}
