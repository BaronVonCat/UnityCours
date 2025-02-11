using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : MonoBehaviour
{
    [SerializeField] private CubesSpawner _cubesSpawner;

    public event Action<List<ExplosiveCube>> Destroying;

    private void OnMouseUpAsButton()
    {
        List<ExplosiveCube> explosiveCubes = _cubesSpawner.SpawnCubes(this);

        Destroying?.Invoke(explosiveCubes);
        Destroy(gameObject);
    }
}
