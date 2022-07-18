using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    public GameObject Model { get; private set; }

    private void Start()
    {
        Model = _enemy;
    }
}
