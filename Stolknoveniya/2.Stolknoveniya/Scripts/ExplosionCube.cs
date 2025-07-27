using UnityEngine;

public class ExplosionCube : MonoBehaviour
{
    private const float DividerTwo = 2;

    [SerializeField] private CoubSpawner spawner;
    [SerializeField] private float _chanceSpawn = 1f;

    private void OnMouseDown()
    {
        float roll = Random.Range(0f, 1f);

        if (roll <= _chanceSpawn)
        {
            _chanceSpawn /= DividerTwo;
            spawner.Spawn(gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
