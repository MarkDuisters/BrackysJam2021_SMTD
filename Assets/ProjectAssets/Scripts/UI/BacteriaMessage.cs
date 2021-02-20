using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BacteriaMessage : MonoBehaviour
{

    [SerializeField] string tag = "Player";
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject canvas;
    [SerializeField] string message = "Not enough bacteria to pass this valve. Your bacteria: ";
    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {
        if (col.tag != tag)
        {
            return;

        }
        else
        {
            if (GameManager.instance.creatureCount < GameManager.instance.maxCreatures)
            {
                text.SetText (message + GameManager.instance.creatureCount);
                StartCoroutine (ShowText ());
            }
            else if (GameManager.instance.creatureCount >= GameManager.instance.maxCreatures)
            {
                GetComponent<TriggerCallAudioEvent> ().enabled = true;
            }

        }
    }

    IEnumerator ShowText ()
    {

        canvas.SetActive (true);
        yield return new WaitForSeconds (10);
        canvas.SetActive (false);

    }
}