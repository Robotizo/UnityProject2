using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    private bool isBallLaunched = false;
    private bool isAiming = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isAiming = Input.GetMouseButton(1);
        if (!isBallLaunched && !isAiming)
        {
            float moveInput = Input.GetAxis("Horizontal"); 
            rb.velocity = new Vector3(moveInput * speed, rb.velocity.y, rb.velocity.z);
        }
    }

    public void SetBallLaunched() => isBallLaunched = true;
}
