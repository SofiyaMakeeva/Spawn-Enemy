using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _enemy;

    private Transform[] _points;
    private WaitForSeconds _waitingTime = new WaitForSeconds(2);

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newEnemy = Instantiate(_enemy.Model, _points[i].position, Quaternion.identity);

            yield return _waitingTime;
        } 
    }
}
