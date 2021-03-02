using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private float _zPositionDifference;
    [SerializeField] private float _fovMin;
    [SerializeField] private float _fovMax;
    [SerializeField] private float _elevation;
    private Camera _camera;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        _camera = GetComponent<Camera>();
        EventManager.OnCylinderCollected.AddListener(FOV);
        EventManager.OnCylinderSlammed.AddListener(FOV);
        EventManager.OnMultiplierPlatform.AddListener(Elevate);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnCylinderCollected.RemoveListener(FOV);
        EventManager.OnCylinderSlammed.RemoveListener(FOV);
        EventManager.OnMultiplierPlatform.RemoveListener(Elevate);
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
        CharacterManager.Instance.Player.transform.position.z - _zPositionDifference);
    }

    private void FOV()
    {
        _camera.fieldOfView = _fovMin + CylinderManager.Instance.ActiveCylinders.Count * 2f;
        if (_camera.fieldOfView > _fovMax)
            _camera.fieldOfView = _fovMax;
    }

    private void Elevate()
    {
        transform.DOMoveY(transform.position.y + _elevation, 0.5f);
    }
}