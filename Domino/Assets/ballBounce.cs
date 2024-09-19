using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float bounceForceUp = 3f;     // How much force to apply in the upward direction
    public float bounceForceSide = 4f;   // How much force to apply sideways

    private Rigidbody ballRigidbody;

    // Detect when the ball hits the paddle
    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRigidbody != null)
            {
                // Apply a slight upward and sideways bounce
                Vector3 bounceDirection = Vector3.up * bounceForceUp + Vector3.right * -bounceForceSide;

                // Reset the ball's velocity and apply the bounce
                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.AddForce(bounceDirection, ForceMode.Impulse);
            }
        }
    }
}
