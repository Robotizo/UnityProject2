using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new UnityEvent();
    private bool isPinFallen = false;

    private void OnTriggerEnter(Collider other)
    {
     
        if (!isPinFallen && other.CompareTag("Ground"))
        {
            isPinFallen = true;
            Debug.Log($"{gameObject.transform.parent.name} has fallen!");
            OnPinFall?.Invoke();

        }
    }
}
