using UnityEngine;

public class SpawnDNA_Knife : MonoBehaviour
{
    [SerializeField] private DNAChance chance;
    [SerializeField] private GameObject[] targetsDNA;
    [SerializeField] private GameObject[] targetsKnife;

    private void Start()
    {
        SpawnKnifes();
        SpawnDNA();
    }

    void SpawnKnifes()
    {
        if (Stage.currentStage == 0)
        {
            int randomKnifes = Random.Range(0, 2);
            for (int i = 0; i < randomKnifes; i++)
            {
                ActiveKnife();
            }
        }
        else if (Stage.currentStage == 1)
        {
            int randomKnifes = Random.Range(1, 3);
            for (int i = 0; i < randomKnifes; i++)
            {
                ActiveKnife();
            }
        }
        else if (Stage.currentStage == 2)
        {
            int randomKnifes = Random.Range(2, 4);
            for (int i = 0; i < randomKnifes; i++)
            {
                ActiveKnife();
            }
        }
        else if (Stage.currentStage == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                ActiveKnife();
            }
        }

        void ActiveKnife()
        {
            int randomTarget = Random.Range(0, 3);
            if (!targetsKnife[randomTarget].activeInHierarchy)
            {
                targetsKnife[randomTarget].SetActive(true);
            }
            else
            {
                ActiveKnife();
            }
        }
    }

    void SpawnDNA()
    {
        int random = Random.Range(0, 100);
        if(random <= chance.Chance)
        {
            int randomDNA = Random.Range(0, 4);
            targetsDNA[randomDNA].SetActive(true);
        }
    }
}
