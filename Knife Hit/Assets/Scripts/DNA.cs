using UnityEngine;
using UnityEngine.UI;

public class DNA : MonoBehaviour
{
    [SerializeField] private Text[] dnaText;
    [SerializeField] private Text dnaAddText;
    private int dna;

    public int DNA_Number
    {
        get
        {
            return dna;
        }
        set
        {
            dna = value;
        }
    }
    private void Update()
    {
        for (int i = 0; i < dnaText.Length; i++)
        {
            dnaText[i].text = dna.ToString();
        }

        if (dnaAddText.gameObject.activeInHierarchy)
        {
            dnaAddText.GetComponent<CanvasGroup>().alpha -= 0.01f;
        }
    }

    public void AddDNA(int DNA)
    {
        dna += DNA;
        Save.SaveDNA(dna);
    }

    public void AddDNA(int DNA, GameObject gameObject)
    {
        dna += DNA;
        Save.SaveDNA(dna);

        dnaAddText.GetComponent<CanvasGroup>().alpha = 1;
        dnaAddText.text = DNA.ToString();
        dnaAddText.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
