using UnityEngine;

[CreateAssetMenu(fileName = "New Chance", menuName = "DNA Chance", order = 100)]
public class DNAChance : ScriptableObject
{
    [SerializeField] private int chance;

    public int Chance
    {
        get
        {
            return chance;
        }
    }
}
