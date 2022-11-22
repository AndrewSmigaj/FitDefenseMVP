using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{


    public float fadeSpeed = 0.025f;
    public float fadeAmount = 0.0f;

    public Light sceneTransitionLight;
    public Material fadeScreenMat;
    bool _isLoading = false;

    public UnityEvent onSceneLoadBegin = new UnityEvent();
    public UnityEvent onSceneLoadEnd = new UnityEvent();

    Scene persistentScene;

    private void Awake()
    {


        SceneManager.sceneLoaded += SetActiveScene;

        persistentScene = SceneManager.GetActiveScene();



        if (!Application.isEditor)
        {
            SceneManager.LoadSceneAsync(SceneUtils.Names.lobby, LoadSceneMode.Additive);
        }
        else
        {
           // SceneManager.LoadSceneAsync(SceneUtils.Names.lobby);
        }
        //test
       // ChangeScene(SceneUtils.Names.lobby);
    }




    void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }

    public void ChangeScene(string name)
    {
        if (!_isLoading)
        {
            StartCoroutine(LoadScene(name));

        }
    }

    public IEnumerator LoadScene(string name)
    {
        _isLoading = true;
        onSceneLoadBegin?.Invoke();
        yield return StartCoroutine(FadeOut());

        //add light for scene transition
        sceneTransitionLight.intensity = 0.1f;
        yield return StartCoroutine(UnloadActiveScene());

        yield return new WaitForSeconds(3);



        yield return StartCoroutine(LoadNewScene(name));

        sceneTransitionLight.intensity = 0.0f;
        SceneUtils.AlignXRRig(persistentScene, SceneManager.GetActiveScene());
        yield return StartCoroutine(FadeIn());
        onSceneLoadEnd?.Invoke();
        _isLoading = false;
    }

    IEnumerator LoadNewScene(string name)
    {
        AsyncOperation sceneLoadAsyncOp = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        while (!sceneLoadAsyncOp.isDone)
        {
            yield return null;
        }
    }

    IEnumerator UnloadActiveScene()
    {

        AsyncOperation sceneUnloadAsyncOp = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!sceneUnloadAsyncOp.isDone)
        {
            yield return null;
        }
    }


    IEnumerator FadeOut()
    {
        while(fadeAmount <= 1.0)
        {
            yield return new WaitForSeconds(0.1f);
            fadeAmount += fadeSpeed;

            Color currentCol = fadeScreenMat.color;
            currentCol.a = fadeAmount;
            fadeScreenMat.color = currentCol;
        }
        fadeAmount = 1.0f;
    }

    IEnumerator FadeIn()
    {
        while (fadeAmount >= 0.0)
        {
            yield return new WaitForSeconds(0.1f);
            fadeAmount -= fadeSpeed;

            Color currentCol = fadeScreenMat.color;
            currentCol.a = fadeAmount;
            fadeScreenMat.color = currentCol;
        }
        fadeAmount = 0.0f;
    }
    //fade out
}
