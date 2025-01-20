using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class NumericCounter : MonoBehaviour
{
    private float _delayInSeconds = 0.5f;
    private int _value = 0;
    private Coroutine _corutine;
    private WaitForSeconds _delay;
    private PlayerInput _input;

    private void OnEnable()
    {
        _input = GetComponent<PlayerInput>();
        _delay = new WaitForSeconds(_delayInSeconds);
        _input.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _input.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        if (_corutine != null)
        {
            StopCoroutine(_corutine);
            _corutine = null;
        }
        else
        {
            _corutine = StartCoroutine(AddNumber());
        }
    }

    private IEnumerator AddNumber()
    {
        while (enabled)
        {
            _value++;
            Debug.Log(_value);
            yield return _delay;
        }
    }
}
