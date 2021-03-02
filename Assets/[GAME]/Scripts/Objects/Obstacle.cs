using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ISlammable slammable = other.GetComponent<ISlammable>();
        if (slammable != null)
        {
            slammable.Slam();
        }
    }
}