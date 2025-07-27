using UnityEngine;

public class CoubSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] float _scaleMultiplier = 1f;

    public void Spawn(GameObject coub)
    {
        int spawnCount = Random.Range(_spawnCountMin, _spawnCountMax);

        for (int i = 0; i < spawnCount; i++)
        {
            CreateCoub(coub);
        }
    }

    private void CreateCoub(GameObject coub)
    {
        GameObject newGameObject = Instantiate(coub);
        Renderer cloneRendere = newGameObject.GetComponent<Renderer>();
        Material newMaterial = new Material(cloneRendere.material);

        newGameObject.transform.localScale *= _scaleMultiplier;
        cloneRendere.material = newMaterial;
        newGameObject.name = coub.name;
        newMaterial.color = Random.ColorHSV();
    }
}
