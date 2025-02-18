using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 25f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;

    private Rigidbody ballRB;
    private bool isBallLaunched;


    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        transform.parent = ballAnchor; // Attach ball to anchor initially
        transform.localPosition = Vector3.zero; // Reset ball position
        ballRB.isKinematic = true; // Disable physics until launch
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);

        // Log ball
        Debug.Log("Ball launched with force: " + force);
    }
}
