using UnityEngine;
using TMPro;
using System;
using System.Security.Cryptography;

public class UIAimFeedback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI aimFeedbackText;
    [SerializeField] private InteractionModule interactionModule;

    private void Start()
    {
        interactionModule.OnNewInteractionFound += DisplayInteractionText;
        HideInteractionText();
    }

    public void DisplayInteractionText(GameObject interaction) 
    {
        if (interaction == null)
        {
            HideInteractionText();
        }
        else
        {
            aimFeedbackText.enabled = true;
            aimFeedbackText.text = "Press RMB to interact with " + interaction.name;
        }
    }

    public void HideInteractionText()
    {
        aimFeedbackText.enabled = false;

    }

}
