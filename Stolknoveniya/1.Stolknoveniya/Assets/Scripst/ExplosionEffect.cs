using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesSpawner))]
public class ExplosionEffect : MonoBehaviour
{
    [SerializeField, Min(0)] private float _forse;
    [SerializeField, Min(0)] private float _radius;
    [SerializeField, Min(0)] private float _upwardsModifier;

    private CubesSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<CubesSpawner>();
    }

    private void OnEnable()
    {
        _spawner.CubesPlaced += DiscardObjects;
    }

    private void OnDisable()
    {
        _spawner.CubesPlaced -= DiscardObjects;
    }

    public void DiscardObjects(List<ExplosiveCube> explosiveCubes)
    {
        foreach (ExplosiveCube cube in explosiveCubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            rigidbody.AddExplosionForce(_forse, transform.position, _radius, _upwardsModifier);
        }
    }
}
