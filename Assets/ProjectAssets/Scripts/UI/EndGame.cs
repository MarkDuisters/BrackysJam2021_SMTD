using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject playerContainer;
    public GameObject enemyContainer;
    public GameObject endCredits;
    // Start is called before the first frame update
    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player")
        {

            Destroy (enemyContainer);
            Destroy (playerContainer);
            endCredits.SetActive(true);

        }

    }
}