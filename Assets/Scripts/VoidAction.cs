using System;
using UnityEngine;

namespace MakeAShape
{
    [CreateAssetMenu(menuName = "Void Event")]
    public class VoidAction : ScriptableObject
    {
        private Action _action;

        public void AddListener(Action listener)
        {
            _action += listener;
        }
        
        public void RemoveListener(Action listener)
        {
            _action -= listener;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }
    }
}