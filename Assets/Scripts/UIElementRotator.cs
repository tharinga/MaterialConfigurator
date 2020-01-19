using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MakeAShape
{
    public class UIElementRotator : MonoBehaviour
    {
        [SerializeField] private int _rotationSpeed = 700;

        void Update()
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * -_rotationSpeed));
        }
    }
}
