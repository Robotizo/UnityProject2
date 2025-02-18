using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Hit Gutter");

            Rigidbody ballRB = other.GetComponent<Rigidbody>();

         
            ballRB.velocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;

          
            if (!other.gameObject.GetComponent<GutterGuide>())
            {
                other.gameObject.AddComponent<GutterGuide>();
            }
        }
    }
}
