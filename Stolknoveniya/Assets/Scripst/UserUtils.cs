using UnityEngine;

public class UserUtils
{
    public static float GenerateChance()
    {
        const float ChanceMax = 100f;

        return Random.Range(0, ChanceMax);
    }
}
