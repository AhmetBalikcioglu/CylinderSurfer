using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HumanoidCharacter : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnCylinderCollected.AddListener(PositionUpdateCollect);
        EventManager.OnCylinderSlammed.AddListener(PositionUpdateSlam);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnCylinderCollected.RemoveListener(PositionUpdateCollect);
        EventManager.OnCylinderSlammed.RemoveListener(PositionUpdateSlam);
    }

    private void PositionUpdateCollect()
    {
        transform.localPosition = Vector3.up * CylinderManager.Instance.ActiveCylinders.Count * CylinderManager.Instance.cylinderHeight;
        transform.DOLocalMoveY(transform.localPosition.y + 0.3f, 0.1f);
        transform.DOLocalMoveY(CylinderManager.Instance.ActiveCylinders.Count * CylinderManager.Instance.cylinderHeight, 0.1f).SetDelay(0.1f);
    }
    private void PositionUpdateSlam()
    {
        transform.DOLocalMoveY(CylinderManager.Instance.ActiveCylinders.Count * CylinderManager.Instance.cylinderHeight, 0.3f).SetDelay(0.30f + 0.05f * CylinderManager.Instance.ActiveCylinders.Count);
    }
}