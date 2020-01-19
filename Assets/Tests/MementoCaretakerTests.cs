using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MementoCaretakerTests
    {
        private Originator _originator; 

        [SetUp]
        public void SetUp()
        {
            _originator = new Originator();
        }

        private void Arrange(string actions)
        {
            foreach (var action in actions)
            {
                _originator.SetState(action.ToString());
            }
        }

        private string ActUndo(int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                _originator.Undo();
                result += _originator.State;
            }

            return result;
        }
        
        private string ActRedo(int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                _originator.Redo();
                result += _originator.State;
            }

            return result;
        }
        
        [Test]
        public void Undo_Reverses_Actions()
        {
            Arrange("ABC");

            string result = ActUndo(3);
            
            Assert.AreEqual("BA-", result);
        }
        
        [Test]
        public void Redo_Redoes_Actions()
        {
            Arrange("ABC");

            string result = ActUndo(3);
            result += ActRedo(3);
            
            Assert.AreEqual("BA-ABC", result);
        }

        [Test]
        public void Undo_Does_Nothing_When_Undo_History_Empty()
        {
            _originator.Undo();
        }
        
        [Test]
        public void Redo_Does_Nothing_When_Redo_History_Empty()
        {
            _originator.Redo();
        }
    }

    class Originator
    {
        private MementoCaretaker _caretaker = new MementoCaretaker();
        public string State { get; private set; } = "-";

        public void SetState(string state)
        {
            _caretaker.Save(new Memento(this, State));
            State = state;
        }

        private void RestoreState(string state)
        {
            State = state;
        }

        public void Undo()
        {
            _caretaker.Undo(new Memento(this, State));
        }
        
        public void Redo()
        {
            _caretaker.Redo(new Memento(this, State));
        }

        class Memento : IMemento
        {
            private Originator _originator;
            private string _state;
            
            public Memento(Originator originator, string state)
            {
                _originator = originator;
                _state = state;
            }
            public void Restore()
            {
                _originator.RestoreState(_state);
            }
        }
    }
}
