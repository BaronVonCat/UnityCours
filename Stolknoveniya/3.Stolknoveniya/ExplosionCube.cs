using UnityEngine;
using System;

public class ExplosionCube : MonoBehaviour
{
    private const float DividerTwo = 2;

    public static event Action<GameObject> OnClicked;

    [SerializeField] private float _chanceSpawn = 1f;

    private void OnMouseDown()
    {
        float roll = UnityEngine.Random.Range(0f, 1f);

        if (roll <= _chanceSpawn)
        {
            _chanceSpawn /= DividerTwo;
            OnClicked?.Invoke(gameObject);
        }

        Destroy(gameObject);
    }
}
