using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Type color block")]
    public TypeBlock typeBlockColor = TypeBlock.None;
    public Vector3 posStar;
    public List<Material> colorMaterials;
    public bool isFloor2;
    public void OnInit()
    {
        posStar = transform.localPosition;
        //Debug.LogError("Reset vi tri");
    }
    private void Start()
    {
        isFloor2 = false;
        OnInit();
    }
    private void Update()
    {
       
    }
    public enum TypeBlock
    {
        BlockRed,
        BlockBlue,
        BlockGreen,
        BlockYellow,
        None
    }
    void ChangeColor(int color)
    {
        transform.GetComponent<Material>().color = colorMaterials[color].color;
    }
    public void AppearAgain()
    {
       
        if (isFloor2)
        {
            transform.localPosition = new Vector3(posStar.x + 30,posStar.y,posStar.z);
        } 
        else
        transform.localPosition = posStar;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GameManager.GetInstance().ReturnBlock(this.gameObject);
    }
}
