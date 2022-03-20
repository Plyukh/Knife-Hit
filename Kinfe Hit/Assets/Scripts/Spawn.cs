using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] circles = new GameObject[12];
    public static bool spawn;
    private void Awake()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            circles[i] = Resources.Load<GameObject>("Circles/Circle " + i);
        }
    }

    private void Update()
    {
        if (spawn)
        {
            SpawnCircle();
            spawn = false;
        }
    }

    public void SpawnCircle()
    {
        if (Stage.currentStage == 0)
        {
            int random = Random.Range(0, 3);
            Instantiate(circles[random], transform.parent);
        }
        else if (Stage.currentStage == 1)
        {
            int random = Random.Range(3, 6);
            Instantiate(circles[random], transform.parent);
        }
        else if (Stage.currentStage == 2)
        {
            int random = Random.Range(6, 9);
            Instantiate(circles[random], transform.parent);
        }
        else if (Stage.currentStage == 3)
        {
            int random = Random.Range(9, 12);
            Instantiate(circles[random], transform.parent);
        }
    }
}
