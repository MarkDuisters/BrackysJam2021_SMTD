using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject playerContainer;
    public GameObject enemyContainer;
    public GameObject endCredits;

    public AudioSource[] ass;

    void Update ()
    {
        foreach (AudioSource childAss in ass)
        {
            childAss.volume = Mathf.Clamp (1f * Vector3.Distance (childAss.transform.position, Camera.main.transform.position), 0f, 1f);
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player")
        {

            Destroy (enemyContainer);
            Destroy (playerContainer);
            Camera.main.gameObject.GetComponent<AudioListener> ().enabled = true;

        }

    }
}