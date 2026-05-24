using UnityEngine;

public class AimingState : BaseState
{
    private Transform target;
    private Transform turretHead;

    private LineRenderer laserEffect;

    public override void OnStartState()
    {
        Debug.Log("Turn ON Laser effect");

        laserEffect = controller.GetComponentInChildren<LineRenderer>();

        laserEffect.enabled = true;

        turretHead = controller.transform.Find("HEAD");
    }

    public override void OnRunState()
    {
        Debug.Log("Rotate HEAD/TOP to face the target");
        turretHead.transform.LookAt(target.position + Vector3.up);

        if( Vector3.Distance(controller.transform.position, target.position) > 5 )
        {
            controller.ChangeState(new IdleState());
        }
    }

    public override void OnExitState()
    {
        laserEffect.enabled = false;
        Debug.Log("Turn OFF laser effect");
    }

    public AimingState(Transform newTarget)
    {
        target = newTarget;
    }

}
