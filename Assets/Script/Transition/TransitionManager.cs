using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sean
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        [SceneName] public string startScene;
        public CanvasGroup fadeCanvasGroup;
        public float fadeDuration;
        private bool isFade;
        private void Start()
        {
            StartCoroutine(TransitionToScene(startScene));
        }
        public void Transition(string from, string to)
       {
            if (!isFade)
            {
                StartCoroutine(TransitionToScene(from, to));
            }
       }
        private IEnumerator TransitionToScene(string to)
        {
            yield return Fade(1);
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
            //設置新場景為激活場景
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
            EventHandler.CallAfterSceneLoadedEvent();
            yield return Fade(0);
        }
        private IEnumerator TransitionToScene(string from,string to)
       {
            yield return Fade(1);
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
            //設置新場景為激活場景
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount -1);
            SceneManager.SetActiveScene(newScene);
            EventHandler.CallAfterSceneLoadedEvent();
            yield return Fade(0);
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetAlpha">0~1 0是透明 1是黑</param>
        /// <returns></returns>
        private IEnumerator Fade(float targetAlpha)
        {
            isFade = true;
            fadeCanvasGroup.blocksRaycasts = true;
            float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
            while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
            {
                fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha,targetAlpha,speed * Time.deltaTime);
                yield return null;
            }
            fadeCanvasGroup.blocksRaycasts = false;
            isFade = false;
        }
    }
}