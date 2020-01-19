using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MakeAShape
{
    public class MaterialController : MonoBehaviour, IMaterialApplier, IMaterialTargetSetter, IUndoRedoHandler
    {
        private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

        private Renderer _currentRenderer;
        private Material _currentMaterial;
        private MaterialFactory _materialFactory;
        private MementoCaretaker _mementoCaretaker;
        private Action _onStateChanged;
        private bool _isRendererSet;
        
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

        public void SetTargetRenderer(Renderer targetRenderer)
        {
            _currentRenderer = targetRenderer;
            _currentMaterial = targetRenderer.sharedMaterial;
            _isRendererSet = true;
        }

        public void ApplyMaterial(string materialName)
        {
            if (!_isRendererSet) return;
            
            _mementoCaretaker.Save(GetCurrentState());
            ApplyMaterial(_currentRenderer, _materials[materialName]);
        }

        private void ApplyMaterial(Renderer renderer, Material material)
        {
            _currentRenderer = renderer;
            _currentMaterial = material;
            renderer.sharedMaterial = material;
            _onStateChanged?.Invoke();
        }
        
        public void Undo()
        {
            _mementoCaretaker.Undo(GetCurrentState());
        }

        public void Redo()
        {
            _mementoCaretaker.Redo(GetCurrentState());
        }

        public void ResetHistory()
        {
            _mementoCaretaker.Reset();
            _isRendererSet = false;
        }

        public void AddChangeListener(Action listener)
        {
            _onStateChanged += listener;
        }

        private Memento GetCurrentState()
        {
            return new Memento(this, _currentRenderer, _currentMaterial);
        }

        private class Memento : IMemento
        {
            private MaterialController _controller;
            private Renderer _renderer;
            private Material _material;

            public Memento(MaterialController controller, Renderer renderer, Material material)
            {
                _controller = controller;
                _renderer = renderer;
                _material = material;
            }

            public void Restore()
            {
                _controller.ApplyMaterial(_renderer, _material);
            }
        }

       
        
    }
}