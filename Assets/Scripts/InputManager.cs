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
        Debug.Log("Your message here");
    }

    // Update is called once per frame
    void Update()
    {
        // Detect Space key for launching the ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        // Detect movement keys (A and D)
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        OnMove?.Invoke(input);
    }
}
