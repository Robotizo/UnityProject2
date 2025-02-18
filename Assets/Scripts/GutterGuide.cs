using UnityEngine;

public class GutterGuide : MonoBehaviour
{
    private Rigidbody ballRB;
    private float ballSpeed = 20f;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        if (ballRB == null)
        {
            Debug.LogError("No Rigidbody found.");
            return;
        }

        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ballRB.useGravity = false;
    }

    void FixedUpdate()
    {
        if (ballRB != null)
        {
      
            ballRB.velocity = new Vector3(0, 0, ballSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("GutterEnd"))
        {
            Debug.Log("Hit end");


            // Restore
            ballRB.useGravity = true;
            ballRB.velocity = Vector3.zero;

            // Remove this script
            Destroy(this);
        }
    }
}
