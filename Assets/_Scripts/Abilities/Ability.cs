using UnityEngine;
using UnityEditor;

public abstract class Ability : ScriptableObject
{
    public string aName = "new ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCoolDown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}