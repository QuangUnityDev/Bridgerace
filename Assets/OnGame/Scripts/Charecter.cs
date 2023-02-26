using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter : MonoBehaviour
{
   
    [Header("Color Player")]
    public TypePlayer typePlayerColor;
    public int blockOwner;
    public Transform containBlock;
    public Rigidbody rb;
    public float speed;
    public List<GameObject> blockOfPlayer;
    public Animator anim;
    private string currentAnim;
    public enum TypePlayer
    {
        PlayerRed = 0,
        PlayerBlue = 1,
        PlayerGreen = 2,
        PlayerYellow = 3
    }
    public void ChangeAnim(string animName)
    {
        if (animName != currentAnim)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}
