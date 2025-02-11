using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExplosiveCube))]
public class CubesSpawner : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _chanceSpawn;
    [SerializeField, Min(1), Delayed] private float _chanceDivider;
    [SerializeField, Min(0.1f), Delayed] private float _scaleChangeMultiplier;
    [SerializeField, Min(0)] private int _minCount;
    [SerializeField, Min(0)] private int _maxCount;

    private CubeFactory _cubeFactory;
    private ExplosiveCube _explosiveCube;

    public event Action<List<ExplosiveCube>> CubesPlaced;

    private void OnValidate()
    {
        _maxCount = _maxCount < _minCount ? _minCount : _maxCount;
    }

    private void Awake()
    {
        _cubeFactory = new CubeFactory();
        _explosiveCube = GetComponent<ExplosiveCube>();
    }

    private void OnEnable()
    {
        _explosiveCube.Destroying += SpawnCubes;
    }

    private void OnDisable()
    {
        _explosiveCube.Destroying -= SpawnCubes;
    }

    private void SpawnCubes()
    {
        List<ExplosiveCube> explosiveCubes = new List<ExplosiveCube>();
        int count = UnityEngine.Random.Range(_minCount, _maxCount + 1);

        if (UserUtils.GenerateChance() <= _chanceSpawn)
        {
            _chanceSpawn /= _chanceDivider;

            for (int i = 0; i < count; i++)
            {
                ExplosiveCube cube = _cubeFactory.Create(_explosiveCube);

                ProcessChangingCube(cube);
                explosiveCubes.Add(cube);
            }
        }

        CubesPlaced?.Invoke(explosiveCubes);
    }

    private void ProcessChangingCube(ExplosiveCube explosiveCube)
    {
        MeshRenderer meshRenderer;

        explosiveCube.transform.localScale *= _scaleChangeMultiplier;

        if (explosiveCube.TryGetComponent<MeshRenderer>(out meshRenderer))
        {
            meshRenderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }
}
