using UnityEngine;
using System;

public class Save : MonoBehaviour
{
    static private int dna;
    static private int maxRecord;
    static private string skins;

    private void Start()
    {
        GetComponent<DNA>().DNA_Number = PlayerPrefs.GetInt("DNA");
        GetComponent<Score>().MaxScore = PlayerPrefs.GetInt("Record");
        skins = PlayerPrefs.GetString("Skins");
        string elements = "";

        for (int i = 0; i < skins.Length; i++)
        {
            if(skins[i] == '!')
            {
                for (int j = i - 1; j < i && j > -2; j--)
                {
                    if(j == -1)
                    {
                        print(elements);
                        GameObject.Find("Skins Grid").GetComponent<SkinManager>().Skins[Int32.Parse(elements)].Unlock = true;
                        elements = "";
                        break;
                    }

                    else if (skins[j] == '!')
                    {
                        print(elements);
                        GameObject.Find("Skins Grid").GetComponent<SkinManager>().Skins[Int32.Parse(elements)].Unlock = true;
                        elements = "";
                        break;
                    }

                    elements += skins[j];
                }
            }
        }
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

    static public void SaveSkins(int skinIndex)
    {
        skins += (skinIndex.ToString() + "!");
        PlayerPrefs.SetString("Skins", skins);
    }
}
