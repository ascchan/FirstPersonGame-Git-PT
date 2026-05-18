using UnityEngine;

public class CustomPhysicsModule : MonoBehaviour
{
    [SerializeField] private float gravityForce;
    [SerializeField] private float sphereCheckRadius;
    [SerializeField] private LayerMask floorLayerMask;

    public Vector3 upDownForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( IsGrounded() )
        {
            upDownForce.y = 0;
        }
        else
        {
            if(upDownForce.y > -10)
            {
                upDownForce.y = gravityForce * Time.deltaTime;
            }
        }
    }

    public void AddJumpForce(float force)
    {
        if( IsGrounded() )
        {
            upDownForce.y = force;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, sphereCheckRadius, floorLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereCheckRadius);
    }
}
