using System.Collections.Generic;
using _Project.Development.ZombieSurvivalCore.Enemies;
using _Project.Development.ZombieSurvivalCore.MainCharacter;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Development.Core.Pause
{
    public class GamePause : MonoBehaviour
    {
        [Inject] private Character _character;
        [Inject] private EnemiesManager _enemiesManager;
        
        private List<IPauseable> _pauseObjects;
        private bool _isPaused;

        public static GamePause Instance;

        private void Awake()
        {
            Instance = this;
            _pauseObjects = new List<IPauseable>();
        }

        public void PauseGame()
        {
            _pauseObjects.Clear();
            _isPaused = true;
            
            _character.Pause();
            
            var sceneObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var pauseObject in sceneObjects)
            {
                if (pauseObject.TryGetComponent<IPauseable>(out var pauseable))
                {
                    pauseable.Pause();
                    _pauseObjects.Add(pauseable);
                }
            }
        }

        public void ResumeGame()
        {
            _isPaused = false;
            _character.Resume();
            
            foreach (var pauseable in _pauseObjects)
            {
                pauseable.Resume();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_isPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }
}