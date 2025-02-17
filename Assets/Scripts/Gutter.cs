using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // ✅ Make sure the ball has the "Ball" tag
        {
            Rigidbody ballRB = other.GetComponent<Rigidbody>();

            // Reset Ball Physics
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;

            // Reset Ball Position
            other.transform.position = new Vector3(0, 1, 0); // Adjust based on your scene
        }
    }
}
