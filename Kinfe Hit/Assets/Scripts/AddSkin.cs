using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddSkin : MonoBehaviour
{
    public void AddNewSkin()
    {
        int random = Random.Range(0, SkinManager.Skins.Length);

        if(SkinManager.Skins[random].Unlock == false)
        {
            SkinManager.UnlockSkin(random);
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = SkinManager.Skins[random].Sprite;
        }
        else
        {
            AddNewSkin();
        }
    }

    public void SetActive_False()
    {
        gameObject.SetActive(false);
    }
}
