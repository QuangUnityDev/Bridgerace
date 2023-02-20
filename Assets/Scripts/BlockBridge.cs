using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBridge : MonoBehaviour
{
    [Header("Type color block")]
    public TypeBlock typeBlockColor = TypeBlock.None;
    public List<Material> colorMaterials;
    private void Start()
    {      
    }
    public enum TypeBlock
    {
        BlockRed = 0,
        BlockBlue = 1,
        BlockGreen = 2,
        BlockYellow = 3,
        None = 4
    }
    void ChangeColor(int color)
    {
        transform.GetComponent<MeshRenderer>().material = colorMaterials[color];
        typeBlockColor = TypeBlock.BlockGreen;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.childCount > 0 && (int)typeBlockColor != (int)collision.transform.GetComponent<PlayerInf>().typePlayerColor)
        {
            int child = collision.transform.childCount;
            GameObject buildFill = collision.gameObject.transform.GetChild(child - 1).gameObject;
            buildFill.transform.SetParent(null);    
            ChangeColor((int)collision.transform.GetComponent<PlayerInf>().typePlayerColor);
            buildFill.GetComponent<Block>().AppearAgain();
        }
    }
    public static bool isOnBridge;
    private void OnCollisionStay(Collision collision)
    {
        isOnBridge = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnBridge = false;
    }
}
