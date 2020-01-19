using System;

namespace MakeAShape.MaterialEditing
{
    public interface IUndoRedoHandler
    {
        bool HasUndoActions { get; }
        bool HasRedoActions { get; }
        void Undo();
        void Redo();
        void ResetHistory();
        void AddChangeListener(Action listener);
    }
}