using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    public UnityEvent OnPressurePadActivate;
    public UnityEvent OnPressurePadDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        OnPressurePadActivate.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnPressurePadDeactivate.Invoke();
    }

}
