using _Project.Development.Core.UIBase;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Development.ZombieSurvivalCore.UI
{
    public class DeathWindow : Window
    {
        public override void Show()
        {
            Cursor.visible = true;
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            Cursor.visible = false;
            gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            UiSystem.HideWindow(Id);
            SceneManager.LoadScene("Village");
        }

        public void ExitGame()
        {
            Debug.Log("Ну ты типа в меню вышел");
        }
    }
}