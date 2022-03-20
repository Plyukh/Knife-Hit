using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddSkin : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;

    public void AddNewSkin()
    {
        int random = Random.Range(0, skinManager.Skins.Length);

        if(skinManager.Skins[random].Unlock == false)
        {
            skinManager.UnlockSkin(random);
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = skinManager.Skins[random].Sprite;
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
