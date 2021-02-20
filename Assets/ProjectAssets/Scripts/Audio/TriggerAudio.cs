using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] GameObject ass;
    [SerializeField] string tag = "Player";
    // Start is called before the first frame update
    void OnTriggerEnter (Collider col)
    {
        if (col.tag != tag)
        {
            return;

        }
        else
        {
            ass.SetActive (true);
            gameObject.SetActive (false);
        }
    }
}