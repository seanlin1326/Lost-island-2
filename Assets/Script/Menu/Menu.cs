using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Sean
{
    public class Menu : MonoBehaviour
    {
        public void QuitGame()
        {

        } 
        public void ContinueGame()
        {
            //�[���C���i��
        }
        public void GoBackToMenu()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            TransitionManager.Instance.Transition(currentScene,"Menu");
            //�O�s�C���i��
        }
    }
}