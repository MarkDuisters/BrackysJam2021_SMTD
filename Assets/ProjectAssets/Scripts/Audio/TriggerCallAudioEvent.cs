using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class TriggerCallAudioEvent : MonoBehaviour
{

    [SerializeField] Animator anim;

    void Start ()
    {
        if (anim == null)
            anim = GetComponent<Animator> ();
    }

    void PlayAudio (AudioClip clip)
    {
        GetComponent<AudioSource> ().PlayOneShot (clip);
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player")
        {
            anim.SetBool ("Open", true);
        }
    }
    void OnTriggerExit (Collider col)
    {
        if (col.tag == "Player")
        {
            anim.SetBool ("Open", false);
        }
    }
}