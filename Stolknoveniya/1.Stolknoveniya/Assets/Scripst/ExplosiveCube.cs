using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : MonoBehaviour
{
    public event Action Destroying;

    private void OnMouseUpAsButton()
    {
        Destroying?.Invoke();
        Destroy(gameObject);
    }
}
