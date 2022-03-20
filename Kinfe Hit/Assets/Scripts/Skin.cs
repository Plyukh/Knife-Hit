using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin", order = 100)]
public class Skin : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool unlock;
    [SerializeField] private Material knifeMaterial;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
    public bool Unlock
    {
        get
        {
            return unlock;
        }
        set
        {
            unlock = value;
        }
    }

    public Material KnifeMaterial
    {
        get
        {
            return knifeMaterial;
        }
    }
}
