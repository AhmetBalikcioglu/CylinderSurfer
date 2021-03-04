using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform _pin;
    [SerializeField] private Image _fill;
    private Vector3 _finish;
    private Vector3 _start;
    private float _pinXClamp;
    private float _courseLenght;
    private Transform _player;

    private void Start()
    {
        _player = CharacterManager.Instance.Player.transform;
        _start = _player.position;
        _finish = GameObject.FindGameObjectWithTag("FinishLine").transform.position;
        _courseLenght = Vector3.Distance(_finish, _start);
        _pinXClamp = _fill.GetComponent<RectTransform>().rect.width;
    }
    private void Update()
    {
        _fill.fillAmount = (_player.position.z - _start.z) / _courseLenght;
        if (_pin.anchoredPosition.x >= 0 && _pin.anchoredPosition.x <= _pinXClamp)
            _pin.anchoredPosition = new Vector2(_pinXClamp * _fill.fillAmount, _pin.anchoredPosition.y);
    }


}
