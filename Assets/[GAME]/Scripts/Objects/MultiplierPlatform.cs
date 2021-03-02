using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierPlatform : MonoBehaviour
{
    [SerializeField] private float _multiplier;

    private void OnTriggerEnter(Collider other)
    {
        ISlammable slammable = other.GetComponent<ISlammable>();
        if (slammable != null)
        {
            slammable.Slam(_multiplier);
        }
    }
}