using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Vector3 direction = rb.velocity.normalized;
            float speed = collision.relativeVelocity.magnitude;

            Debug.Log("Collision detected with TargetTag!");
            Debug.Log("Direction: " + direction);
            Debug.Log("Speed: " + speed);
            // اعمال اقدامات لازم
        }
    }
}
