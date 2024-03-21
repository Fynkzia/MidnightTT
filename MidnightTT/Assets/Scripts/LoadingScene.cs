using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScene : MonoBehaviour {
    [SerializeField] private Image loadingBarFill;
    [SerializeField] private int sceneId;

    public void Start() {
        LoadScene(sceneId);
    }
    public void LoadScene(int sceneId) {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId) { 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        while (!operation.isDone) {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
