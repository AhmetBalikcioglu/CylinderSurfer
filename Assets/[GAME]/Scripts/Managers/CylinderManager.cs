using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderManager : Singleton<CylinderManager>
{
    private List<Cylinder> _activeCylinders;
    public List<Cylinder> ActiveCylinders { get { return _activeCylinders; } set { _activeCylinders = value; } }

    public float cylinderHeight;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        ActiveCylinders = new List<Cylinder>();
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }
}