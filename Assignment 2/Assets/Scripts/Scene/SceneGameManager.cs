using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneName
{
    Kasra,
    KingstonSence,
    FinZone,
    TinScene,
    EndScene,
}

public class SceneGameManager : SingletonMonobehaviour<SceneGameManager>
{
    [SerializeField] private float transitDuration = 1.0f;
    [SerializeField] private CanvasGroup transitCanvasGroup = null;
    [SerializeField] private Image screenTransitionImage = null;
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private SceneName startingSceneName;
    private bool isTransiting;

    //===========================================================================
    private IEnumerator Start()
    {
        screenTransitionImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        transitCanvasGroup.alpha = 1.0f;

        yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName.ToString()));

        EventHandler.CallAfterSceneLoadEvent();

        StartCoroutine(TransitAlpha(0.0f));
    }

    //===========================================================================
    public void FadeAndLoadScene(string sceneName, Vector3 spawnPosition)
    {
        if (!isTransiting)
            StartCoroutine(TransitAndSwitchScene(sceneName, spawnPosition));
    }

    //===========================================================================
    private IEnumerator TransitAndSwitchScene(string sceneName, Vector3 spawnPosition)
    {
        EventHandler.CallBeforeSceneUnloadFadeOutEvent();

        yield return StartCoroutine(TransitAlpha(1.0f));

        player.MovePosition(spawnPosition);
        player.transform.position = spawnPosition;

        EventHandler.CallBeforeSceneUnloadEvent();

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));

        EventHandler.CallAfterSceneLoadEvent();

        yield return StartCoroutine(TransitAlpha(0f));

        EventHandler.CallAfterSceneLoadFadeInEvent();
    }

    private IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newLoadedScene);
    }

    private IEnumerator TransitAlpha(float finalAlpha)
    {
        isTransiting = true;
        transitCanvasGroup.blocksRaycasts = true;

        float _fadeSpeed = Mathf.Abs(transitCanvasGroup.alpha - finalAlpha) / transitDuration;

        while (!Mathf.Approximately(transitCanvasGroup.alpha, finalAlpha))
        {
            transitCanvasGroup.alpha = Mathf.MoveTowards(transitCanvasGroup.alpha, finalAlpha, _fadeSpeed * Time.deltaTime);
            yield return null;
        }

        transitCanvasGroup.alpha = finalAlpha;
        isTransiting = false;
        transitCanvasGroup.blocksRaycasts = false;
    }
}
