using System;

namespace MakeAShape
{
    public interface IUndoRedoHandler
    {
        bool HasUndoActions { get; }
        bool HasRedoActions { get; }
        void Undo();
        void Redo();
        void AddChangeListener(Action listener);
    }
}