using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UndoRedoButtons : MonoBehaviour
{
    [SerializeField] private Button _undoButton;
    [SerializeField] private Button _redoButton;
    private IUndoRedoHandler _handler;

    [Inject]
    public void Construct(IUndoRedoHandler handler)
    {
        _handler = handler;
    }
    
    void Start()
    {
        _undoButton.onClick.AddListener(Undo);
        _redoButton.onClick.AddListener(Redo);
        _handler.AddChangeListener(UpdateButtonState);
    }

    void Undo()
    {
        _handler.Undo();
    }

    void Redo()
    {
        _handler.Redo();
    }

    void UpdateButtonState()
    {
        _undoButton.interactable = _handler.HasUndoActions;
        _redoButton.interactable = _handler.HasRedoActions;
    }
}
