using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _chanceSpawn;
    [SerializeField, Min(1), Delayed] private float _chanceDivider;
    [SerializeField, Min(0.1f), Delayed] private float _scaleChangeMultiplier;
    [SerializeField, Min(0)] private int _minCount;
    [SerializeField, Min(0)] private int _maxCount;

    private CubeFactory _cubeFactory;
    
    private void OnValidate()
    {
        _maxCount = _maxCount < _minCount ? _minCount : _maxCount;
    }

    private void Awake()
    {
        _cubeFactory = new CubeFactory();
    }

    public List<ExplosiveCube> SpawnCubes(ExplosiveCube explosiveCube)
    {
        List<ExplosiveCube> explosiveCubes = new List<ExplosiveCube>();
        int count = Random.Range(_minCount, _maxCount + 1);

        if (UserUtils.GenerateChance() <= _chanceSpawn)
        {
            _chanceSpawn /= _chanceDivider;

            for (int i = 0; i < count; i++)
            {
                ExplosiveCube cube = _cubeFactory.Create(explosiveCube);

                ProcessChangingCube(cube);
                explosiveCubes.Add(cube);
            }
        }

        return explosiveCubes;
    }

    private void ProcessChangingCube(ExplosiveCube explosiveCube)
    {
        explosiveCube.transform.localScale *= _scaleChangeMultiplier;
        explosiveCube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
