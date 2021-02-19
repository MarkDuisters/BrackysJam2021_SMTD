using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioZone : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    AudioSource ass;
    [SerializeField] Transform audioSrc;
        [SerializeField] Transform followTarget;


    [SerializeField] Vector3 SpawnBounds;

    void Start ()
    {
        ass = audioSrc.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (!ass.isPlaying)
        {
            int rng = Random.Range (0, clips.Length - 1);

            float x, y, z;
            x = followTarget.position.x + Random.Range (-SpawnBounds.x / 2f, SpawnBounds.x / 2f);
            y = followTarget.position.y + Random.Range (-SpawnBounds.y / 2f, SpawnBounds.y / 2f);
            z = followTarget.position.z + Random.Range (-SpawnBounds.z / 2f, SpawnBounds.z / 2f);

            audioSrc.position = new Vector3 (x, y, z);

            ass.PlayOneShot (clips[rng]);

        }

    }
}