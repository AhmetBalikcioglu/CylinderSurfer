using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float _lastMultiplier = 20f;
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            GameManager.Instance.GameEnd();
            EventManager.OnScoreMultiply.Invoke(_lastMultiplier);
        }
    }
}
