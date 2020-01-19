using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MakeAShape
{
    public class MaterialController : MonoBehaviour, IMaterialApplier, IMaterialTargetSetter, IUndoRedoHandler
    {
        private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

        private MaterialFactory _materialFactory;
        private MementoCaretaker _mementoCaretaker;
        
        private MaterialTarget _currentTarget;
        private Action _onStateChanged;
        private bool _isTargetSet;
        
        public bool HasUndoActions => _mementoCaretaker.HasUndoActions;
        public bool HasRedoActions => _mementoCaretaker.HasRedoActions;

        [Inject]
        public void Construct(MaterialFactory materialFactory, MementoCaretaker mementoCaretaker)
        {
            _materialFactory = materialFactory;
            _mementoCaretaker = mementoCaretaker;
        }
        
        public void LoadMaterials(List<MaterialProperties> materialProperties)
        {
            foreach (var material in materialProperties)
            {
                _materials[material.Name] = _materialFactory.CreateMaterial(material);
            }
        }

        public void SetMaterialTarget(MaterialTarget materialTarget)
        {
            if (_currentTarget != null)
            {
                SaveMemento();
            }
            _currentTarget = materialTarget;
            _isTargetSet = true;
        }

        public void ApplyMaterial(string materialName)
        {
            if (!_isTargetSet) return;

            SaveMemento();
            ApplyMaterial(_currentTarget, _materials[materialName]);
        }
        
        private void ApplyMaterial(MaterialTarget target, Material material)
        {
            _currentTarget = target;
            _currentTarget.SetMaterial(material);
            _onStateChanged?.Invoke();
        }
        
        public void Undo()
        {
            _mementoCaretaker.Undo(CreateMemento());
        }

        public void Redo()
        {
            _mementoCaretaker.Redo(CreateMemento());
        }

        public void ResetHistory()
        {
            _mementoCaretaker.Reset();
            _isTargetSet = false;
            _onStateChanged?.Invoke();
        }

        public void AddChangeListener(Action listener)
        {
            _onStateChanged += listener;
        }

        private void SaveMemento()
        {
            _mementoCaretaker.Save(CreateMemento()); 
        }

        private Memento CreateMemento()
        {
            return new Memento(this, _currentTarget, _currentTarget.Material);
        }

        private class Memento : IMemento
        {
            private MaterialController _controller;
            private MaterialTarget _target;
            private Material _material;

            public Memento(MaterialController controller, MaterialTarget target, Material material)
            {
                _controller = controller;
                _target = target;
                _material = material;
            }
            
            public void Restore()
            {
                _controller.ApplyMaterial(_target, _material);
            }
        }
    }
}