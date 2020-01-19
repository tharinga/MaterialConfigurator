using System.Collections.Generic;

namespace MakeAShape
{
    public class MementoCaretaker
    {
        private Stack<IMemento> _undo = new Stack<IMemento>();
        private Stack<IMemento> _redo = new Stack<IMemento>();

        public bool HasUndoActions => _undo.Count > 0;
        public bool HasRedoActions => _redo.Count > 0;
        
        public void Save(IMemento memento)
        {
            _undo.Push(memento);
            _redo.Clear();
        }

        public void Undo(IMemento current)
        {
            if (!HasUndoActions) return;

            _redo.Push(current);
            var memento = _undo.Pop();
            memento.Restore();
        }

        public void Redo(IMemento current)
        {
            if (!HasRedoActions) return;
            
            _undo.Push(current);
            var memento = _redo.Pop();
            memento.Restore();
        }
    }
}