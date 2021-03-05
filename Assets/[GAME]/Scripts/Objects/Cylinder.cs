using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cylinder : MonoBehaviour, ICollectable, ISlammable
{
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }

    private BoxCollider _boxCollider;
    public BoxCollider BoxCollider { get { return (_boxCollider == null) ? _boxCollider = GetComponent<BoxCollider>() : _boxCollider; } }

    [SerializeField] private GameObject _plusOneText;

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

    public void Collect()
    {
        transform.parent = CharacterManager.Instance.Player.transform;
        CylinderManager.Instance.ActiveCylinders.Add(this);
        EventManager.OnCylinderCollected.Invoke();
        GameObject tempTextGO = Instantiate(_plusOneText, transform);
        tempTextGO.transform.position += Vector3.right;
        Destroy(tempTextGO, 0.5f);
    }

    private void PositionUpdateCollect()
    {
        if (!CylinderManager.Instance.ActiveCylinders.Contains(this))
            return;
        transform.localPosition = Vector3.up * CylinderManager.Instance.ActiveCylinders.IndexOf(this) * CylinderManager.Instance.cylinderHeight;
    }
    private IEnumerator PositionUpdateSlam()
    {
        if (!CylinderManager.Instance.ActiveCylinders.Contains(this))
            yield break;
        yield return new WaitForSeconds(CylinderManager.Instance.slamGravityTimer);
        transform.DOLocalMoveY(CylinderManager.Instance.ActiveCylinders.IndexOf(this) * CylinderManager.Instance.cylinderHeight, 0.3f).SetDelay(0.05f * CylinderManager.Instance.ActiveCylinders.IndexOf(this));
    }

    public void Slam()
    {
        if (!CylinderManager.Instance.ActiveCylinders.Contains(this))
            return;
        CylinderManager.Instance.ActiveCylinders.Remove(this);
        transform.parent = null;
        BoxCollider.isTrigger = false;
        Rigidbody.isKinematic = false;
        Rigidbody.useGravity = true;
        EventManager.OnCylinderSlammed.Invoke();
        if (CylinderManager.Instance.ActiveCylinders.Count == 0)
        {
            GameManager.Instance.GameEnd();
            EventManager.OnLevelFail.Invoke();
        }
    }

    public void Slam(float multiplier)
    {
        if (!CylinderManager.Instance.ActiveCylinders.Contains(this))
            return;
        CylinderManager.Instance.ActiveCylinders.Remove(this);
        transform.parent = null;
        BoxCollider.isTrigger = false;
        Rigidbody.isKinematic = false;
        Rigidbody.useGravity = true;
        EventManager.OnMultiplierPlatform.Invoke();
        if (CylinderManager.Instance.ActiveCylinders.Count == 0)
        {
            GameManager.Instance.GameEnd();
            EventManager.OnScoreMultiply.Invoke(multiplier - 1);
        }
    }
}