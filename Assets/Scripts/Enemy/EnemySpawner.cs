﻿using LudumDare51.SO;
using UnityEngine;

namespace LudumDare51.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;

        [SerializeField]
        private EnemyInfo[] _enemyInfo;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private Node _firstNode;

        private void Start()
        {
            for (int i = 0; i < 10f; i++)
            {
                var targetInfo = _enemyInfo[Random.Range(0, _enemyInfo.Length)];
                var go = Instantiate(_enemyPrefab, transform);
                var offset = (Vector2)(Random.insideUnitSphere * .25f);
                go.transform.position = (Vector2)(_spawnPoint.position) + offset;
                var enemy = go.GetComponent<EnemyAI>();
                enemy.Info = targetInfo;
                enemy.NextNode = _firstNode;
                enemy.Offset = offset;
            }
        }
    }
}
