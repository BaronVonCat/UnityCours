using UnityEngine;

public class CubeFactory
{
    public ExplosiveCube Create(ExplosiveCube explosionCube)
    {
        return Object.Instantiate(explosionCube, explosionCube.transform.position, Quaternion.identity);
    }
}
