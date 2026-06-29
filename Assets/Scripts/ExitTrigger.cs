using TMPro;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if( other.CompareTag("Player") )
        {
            gameManager.GameOver();
        }


    }
}
