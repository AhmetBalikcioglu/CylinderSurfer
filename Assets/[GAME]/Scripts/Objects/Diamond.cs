using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectable
{
    [SerializeField] private float _scorePoint;
    [SerializeField] private ParticleSystem _collectEffect;
    public void Collect()
    {
        EventManager.OnScoreUpdate.Invoke(_scorePoint);
        Instantiate(_collectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
