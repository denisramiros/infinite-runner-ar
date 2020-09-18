using UnityEngine;

namespace Resources.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private GameController gameController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                gameController.GameOver();
            }
        }
    }
}
