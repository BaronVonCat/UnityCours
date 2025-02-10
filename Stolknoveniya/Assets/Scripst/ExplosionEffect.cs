using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplosiveCube))]
public class ExplosionEffect : MonoBehaviour
{
    [SerializeField, Min(0)] private float _forse;
    [SerializeField, Min(0)] private float _radius;
    [SerializeField, Min(0)] private float _upwardsModifier;

    private void OnEnable()
    {
        GetComponent<ExplosiveCube>().Destroying += DiscardObjects;
    }

    private void OnDisable()
    {
        GetComponent<ExplosiveCube>().Destroying -= DiscardObjects;
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
