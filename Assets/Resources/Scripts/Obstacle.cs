using UnityEngine;

namespace Resources.Scripts
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3.5f;

        private void Update()
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boundary"))
            {
                Destroy(gameObject);
            }
        }
    }
}
