using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject _enemy;

    private Transform[] _points;
    private float _waitingTime = 2f;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        if (_enemy.TryGetComponent<Enemy>(out Enemy enemy))
        {
            StartCoroutine(SpawnEnemy());
        } 
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newEnemy = Instantiate(_enemy, _points[i].position, Quaternion.identity);

            yield return new WaitForSeconds(_waitingTime);
        } 
    }
}
