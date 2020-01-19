using System;
using UnityEngine;

namespace MakeAShape
{
    [CreateAssetMenu(menuName = "String Event")]
    public class StringEvent : ScriptableObject
    {
        private Action<string> _stringEvent;

        public void AddListener(Action<string> listener)
        {
            _stringEvent += listener;
        }
        
        public void RemoveListener(Action<string> listener)
        {
            _stringEvent -= listener;
        }

        public void Invoke(string message)
        {
            _stringEvent?.Invoke(message);
        }
    }
}