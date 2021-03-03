using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private float _moveSpeedForward;
    [SerializeField] private float _xPositionLimit;
    [SerializeField] private bool _isRunning;
    public bool IsRunning { get { return _isRunning; } set { _isRunning = value; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnSwipeDetected.AddListener(Surf);
        EventManager.OnGameStart.AddListener(() => IsRunning = true);
        EventManager.OnLevelFinish.AddListener(() => IsRunning = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnSwipeDetected.RemoveListener(Surf);
        EventManager.OnGameStart.RemoveListener(() => IsRunning = true);
        EventManager.OnLevelFinish.RemoveListener(() => IsRunning = false);
    }

    private void Update()
    {
        if (!IsRunning)
            return;
        Run();
    }

    public void Run()
    {
        transform.position += Vector3.forward * _moveSpeedForward * Time.deltaTime;
    }

    public void Surf(float xPosition)
    {
        transform.position += Vector3.right * xPosition * Time.deltaTime;
        Clamp();
    }

    private void Clamp()
    {
        if (transform.position.x < -_xPositionLimit)
            transform.position = new Vector3(-_xPositionLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > _xPositionLimit)
            transform.position = new Vector3(_xPositionLimit, transform.position.y, transform.position.z);
    }
}