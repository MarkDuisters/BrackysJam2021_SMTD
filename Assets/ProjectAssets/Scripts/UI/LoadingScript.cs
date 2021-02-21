using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{

    public Slider slider;
    public int sceneIndex;
    // Update is called once per frame
    void Start ()
    {
        StartCoroutine (LoadingScreneLoad (sceneIndex));
    }

    IEnumerator LoadingScreneLoad (int sceneIndex)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync (sceneIndex);

        while (!loadingOperation.isDone)

        {
            slider.value = Mathf.Clamp01 (loadingOperation.progress / 0.9f);
            yield return null;
        }

    }
}