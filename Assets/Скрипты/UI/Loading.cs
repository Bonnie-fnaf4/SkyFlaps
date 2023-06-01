using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public string loadlevel;
    public GameObject LoadingScreen;
    public Slider bar;

    public void Load()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
        Time.timeScale = 1;
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadlevel);

        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            yield return null;
        }
    }
}
