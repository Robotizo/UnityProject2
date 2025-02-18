using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 50f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody ballRB;
    private bool isBallLaunched;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();       
        transform.parent = ballAnchor;
        transform.localRotation = Quaternion.identity; 
        ballRB.isKinematic = true;

        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null; 
        ballRB.isKinematic = false; 
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.VelocityChange);
        launchIndicator.gameObject.SetActive(false);



        Debug.Log("Ball launched with force: " + force);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        
  
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

        transform.localRotation = Quaternion.identity; 
        
   
        ballRB.isKinematic = true;
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

     
        if (launchIndicator != null)
        {
            launchIndicator.localPosition = new Vector3(-0.25f, -0.14f, 1.38f);
            launchIndicator.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0); 
        }

 
        launchIndicator.gameObject.SetActive(true);
    }
}
