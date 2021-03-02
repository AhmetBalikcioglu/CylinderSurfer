using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CharacterControllerType { Player, AI }

public class Character : MonoBehaviour
{
    public CharacterControllerType CharacterControllerType = CharacterControllerType.Player;

    private Collider collider;
    public Collider Collider { get { return (collider == null) ? collider = GetComponent<Collider>() : collider; } }

    private bool isControlable;
    public bool IsControlable { get { return isControlable; } set { isControlable = value; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.AddCharacter(this);
        //EventManager.OnLevelFinish.AddListener(() => StopAllCoroutines());
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.RemoveCharacter(this);
        //EventManager.OnLevelFinish.RemoveListener(() => StopAllCoroutines());
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DoorBase>() != null)
        {
            var controller = GetComponent<CharacterAnimationController>();
            if (controller != null)
            {
                controller.InvokeTrigger("Run");
            }
        }
    }*/
}