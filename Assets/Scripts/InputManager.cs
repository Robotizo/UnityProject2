using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("It is working!");
    }

    // Update is called once per frame
    void Update()
    {
        // Detect Space key for launching the ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

    }
}
