using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject _enemy;

    private Transform[] _points;
    private int _currentPoint;
    private float _waitingTime = 2f;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (_currentPoint >= _points.Length)
        {
            StopCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(_points[i].position.x, _points[i].position.y, _points[i].position.z), Quaternion.identity);
            _currentPoint++;
            yield return new WaitForSeconds(_waitingTime);
        } 
    }
}
