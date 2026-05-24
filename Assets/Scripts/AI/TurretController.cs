using UnityEngine;

public class TurretController : MonoBehaviour
{
    public BaseState currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeState( new IdleState() );

    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.OnRunState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = newState;

        currentState.controller = this;
        currentState.OnStartState();
    }
}
