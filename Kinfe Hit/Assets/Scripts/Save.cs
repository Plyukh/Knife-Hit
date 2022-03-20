using UnityEngine;

public class Save : MonoBehaviour
{
    static private int dna;
    static private int maxRecord;

    private void Awake()
    {
        dna = GetComponent<DNA>().DNA_Number;
        maxRecord = GetComponent<Score>().MaxScore;
    }

    private void Start()
    {
        GetComponent<DNA>().DNA_Number = PlayerPrefs.GetInt("DNA");
        GetComponent<Score>().MaxScore = PlayerPrefs.GetInt("Record");
    }

    static public void SaveDNA(int value)
    {
        dna = value;
        PlayerPrefs.SetInt("DNA", dna);
    }
    static public void SaveRecord(int value)
    {
        maxRecord = value;
        PlayerPrefs.SetInt("Record", maxRecord);
    }
}
