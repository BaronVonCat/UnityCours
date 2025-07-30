using UnityEngine;
using System;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] float _scaleMultiplier = 1f;

    private void OnEnable()
    {
        ExplosionCube.OnClicked += Spawn;
    }

    private void OnDisable()
    {
        ExplosionCube.OnClicked -= Spawn;
    }

    public void Spawn(GameObject cube)
    {
        int spawnCount = UnityEngine.Random.Range(_spawnCountMin, _spawnCountMax);

        for (int i = 0; i < spawnCount; i++)
        {
            CreateCoub(cube);
        }
    }

    private void CreateCoub(GameObject cube)
    {
        GameObject newGameObject = Instantiate(cube);

        newGameObject.transform.localScale *= _scaleMultiplier;
        newGameObject.name = cube.name;
    }
}
