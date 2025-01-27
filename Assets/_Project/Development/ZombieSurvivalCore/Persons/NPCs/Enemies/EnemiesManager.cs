using System.Collections.Generic;
using _Project.Development.Core.Pause;
using _Project.Development.ZombieSurvivalCore.Persons.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies
{
    public class EnemiesManager : MonoBehaviour, IPauseable
    {
        [Inject] private IInstantiator _instantiator;
        [Inject] private Character _character;
        
        [SerializeField] private List<Transform> enemySpawnPoints;
        [SerializeField] private int startEnemiesCount;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Transform enemiesContainer;

        private List<Transform> _freePoints;
        private List<Transform> _orderedPoints;
        
        private List<Enemy> _enemies;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _enemies = new List<Enemy>(startEnemiesCount);
            _orderedPoints = new List<Transform>(startEnemiesCount);
            _freePoints = new List<Transform>(enemySpawnPoints.Count);
            
            SpawnEnemies();
        }

        public void SpawnEnemies()
        {
            _orderedPoints.Clear();
            _freePoints.Clear();
            _freePoints.AddRange(enemySpawnPoints);

            for (int i = 0; i < startEnemiesCount; i++)
            {
                var pointIndex = Random.Range(0, _freePoints.Count - 1);
                _orderedPoints.Add(_freePoints[pointIndex]);
                var orderedPoint = _freePoints[pointIndex];
                _freePoints.Remove(orderedPoint);
                SpawnEnemy(orderedPoint);
            }
        }

        private void SpawnEnemy(Transform point)
        {
            var enemy = _instantiator.InstantiatePrefabForComponent<Enemy>(enemyPrefab, point);
            enemy.transform.SetParent(enemiesContainer);
            _enemies.Add(enemy);
        }

        public void Resume()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Resume();
            }
        }

        public void Pause()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Pause();
            }
        }
    }
}