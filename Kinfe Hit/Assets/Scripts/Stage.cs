using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Stage : MonoBehaviour
{
    [SerializeField] private Image stagePanel;
    [SerializeField] AddSkin addSkin;
    private Score score;

    static Image[] stages = new Image[4];
    static public int currentStage = -1;

    static Color32 minionColor = new Color32(170,170,0,255);
    static Color32 bossColor = new Color32(170, 0, 0, 255);
    static Color32 compeleteColor = new Color32(0, 255, 0, 255);

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            stages[i] = gameObject.transform.GetChild(i).GetComponent<Image>();
        }
        score = GameObject.FindWithTag("Menu").GetComponent<Score>();
    }

    public void NextStage()
    {
        score.AddScore(1);
        currentStage += 1;

        stagePanel.color = new Color32(90, 170, 170, 255);

        for (int i = 0; i < stages.Length; i++)
        {
            if(stages[i].transform.GetChild(0).GetComponent<Image>().color != compeleteColor && currentStage >= 1)
            {
                stages[i].transform.GetChild(0).GetComponent<Image>().color = compeleteColor;
                if (currentStage >= 4)
                {
                    if (SkinManager.UnlockAllSkins == false)
                    {
                        addSkin.gameObject.SetActive(true);
                        addSkin.AddNewSkin();
                    }

                    ResetStages(0);
                }
                break;
            }
        }
        KnifeManager.Reload();

        StartCoroutine(PanelColor());
    }

    public void ResetStages(int CurrentStage)
    {
        currentStage = CurrentStage;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i < 3)
            {
                stages[i].transform.GetChild(0).GetComponent<Image>().color = minionColor;
            }
            else
            {
                stages[i].transform.GetChild(0).GetComponent<Image>().color = bossColor;
            }
        }
    }

    IEnumerator PanelColor()
    {
        yield return new WaitForSeconds(0.0001f);

        stagePanel.color -= new Color32(0, 0, 0, 5);

        if (stagePanel.color.a > 0)
        {
            StartCoroutine(PanelColor());
        }
        else
        {
            Spawn.spawn = true;
            StopCoroutine(PanelColor());
        }
    }
}
