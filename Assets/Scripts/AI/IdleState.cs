using UnityEngine;

public class IdleState : BaseState
{
    private PlayerInput player;
    private Transform turretHead;

    public override void OnStartState()
    {
        Debug.Log("Set Skin Color to Green");
        Debug.Log("Play Idle Animation");
        
        player = GameManager.Instance.GetPlayer();
        turretHead = controller.transform.Find("HEAD");
    }

    
    public override void OnRunState()
    {
        Debug.Log("Check distance to player");

        if ( Vector3.Distance(controller.transform.position, player.transform.position) < 7)
        {
            controller.ChangeState( new AimingState(player.transform) );
        }

        turretHead.rotation = Quaternion.Lerp(turretHead.rotation, Quaternion.identity, Time.deltaTime);

    }

    public override void OnExitState()
    {
        Debug.Log("Set Skin Color to default");
        Debug.Log("Stop Idle Animation");
    }

}
