using System;
using UnityEngine;

namespace MakeAShape
{
    [CreateAssetMenu(menuName = "String Action")]
    public class StringAction : ScriptableObject
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