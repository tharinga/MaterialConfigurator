using UnityEngine;

namespace MakeAShape
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 200;
        private Vector3 _position;

        private void Start()
        {
            _position = transform.position;
        }

        private void OnMouseDrag()
        {
            var xDirection = Input.GetAxis("Mouse X");
            var yDirection = Input.GetAxis("Mouse Y");

            transform.RotateAround(_position, Vector3.down, xDirection * _rotationSpeed * Time.deltaTime);
            transform.RotateAround(_position, Vector3.right, yDirection * _rotationSpeed * Time.deltaTime);
        }
    }
}