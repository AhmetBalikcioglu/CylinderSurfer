﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HumanoidCharacter : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnCylinderCollected.AddListener(() => { StopAllCoroutines(); PositionUpdateCollect(); });
        EventManager.OnCylinderSlammed.AddListener(() => StartCoroutine(PositionUpdateSlam()));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnCylinderCollected.RemoveListener(() => { StopAllCoroutines(); PositionUpdateCollect(); });
        EventManager.OnCylinderSlammed.RemoveListener(() => StartCoroutine(PositionUpdateSlam()));
    }

    private void PositionUpdateCollect()
    {
        transform.localPosition = Vector3.up * ((CylinderManager.Instance.ActiveCylinders.Count - 1) * CylinderManager.Instance.cylinderHeight + 0.375f);
        transform.DOLocalMoveY(transform.localPosition.y + 0.1f, 0.1f);
        transform.DOLocalMoveY((CylinderManager.Instance.ActiveCylinders.Count - 1) * CylinderManager.Instance.cylinderHeight + 0.375f, 0.1f).SetDelay(0.1f);
    }
    private IEnumerator PositionUpdateSlam()
    {
        yield return new WaitForSeconds(CylinderManager.Instance.slamGravityTimer);
        transform.DOLocalMoveY((CylinderManager.Instance.ActiveCylinders.Count - 1) * CylinderManager.Instance.cylinderHeight + 0.375f, 0.3f).SetDelay(0.05f * CylinderManager.Instance.ActiveCylinders.Count);
    }
}