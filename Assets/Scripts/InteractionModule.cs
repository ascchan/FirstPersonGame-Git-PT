using UnityEngine;

public class InteractionModule : MonoBehaviour
{
    [SerializeField] private Transform rayOriginTransform;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayer;

    private GameObject highlightedInteraction;
    private Interactable pickUpInteraction;

    // Update is called once per frame
    void Update()
    {
        Ray imaginaryLine = new Ray(rayOriginTransform.position, rayOriginTransform.forward * interactionRange);

        RaycastHit hitInfo;

        if( Physics.Raycast(imaginaryLine, out hitInfo, interactionRange, interactableLayer) )
        {
            Debug.Log( "Press F to interact" );
            //Debug.Log(hitInfo.collider.name);
            highlightedInteraction = hitInfo.collider.gameObject;
        }
        else
        {
            highlightedInteraction = null;
        }

        Debug.DrawRay(rayOriginTransform.position, rayOriginTransform.forward * interactionRange, Color.yellow);

    }

    public void StartInteraction()
    {
        if(highlightedInteraction != null)
        {
            //Debug.Log(Vector3.Distance(transform.position, highlightedInteraction.transform.position));
            //detect the distance between the player and the interactable object, if it's too far, don't interact with it

            Interactable interaction = highlightedInteraction.GetComponent<Interactable>();
            interaction.OnStartInteraction.Invoke();

            if(interaction is PickUpInteractable)
            {
                pickUpInteraction = interaction;
                pickUpInteraction.transform.SetParent(rayOriginTransform);
            }
        }
    }

    public void StopInteraction()
    {
        if(pickUpInteraction != null)
        {
            pickUpInteraction.OnStopInteraction.Invoke();
            pickUpInteraction.transform.SetParent(null);
            pickUpInteraction = null;
        }
    }

}
