using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericCounter : MonoBehaviour
{
    private bool _isPlaying = false;
    private float _delayInSeconds = 0.5f;
    private int _value = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isPlaying)
            {
                _isPlaying = false;
            }
            else
            {
                _isPlaying = true;
                StartCoroutine(AddNumber());
            }
        }
    }

    private IEnumerator AddNumber()
    {
        while (_isPlaying == true)
        {
            _value++;
            Debug.Log(_value);
            yield return new WaitForSeconds(_delayInSeconds);
        }
    }
}
