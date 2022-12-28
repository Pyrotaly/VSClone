using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GenericMenuFader
{
    public class SceneTransistionFader : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private int levelToLoad;

        public void FadeToLevel(int levelIndex)
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("FadeOut");
        }

        // This is a unity animation event function
        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
