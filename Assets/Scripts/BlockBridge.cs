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
        switch (color)
        {
            case 0:
                typeBlockColor = TypeBlock.BlockRed;
                break;
            case 1:
                typeBlockColor = TypeBlock.BlockBlue;
                break;
            case 2:
                typeBlockColor = TypeBlock.BlockGreen;
                break;
            case 3:
                typeBlockColor = TypeBlock.BlockYellow;
                break;
            case 4:
                typeBlockColor = TypeBlock.None;
                break;

            default:
                break;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.childCount > 0 && (int)typeBlockColor != (int)collision.transform.GetComponent<PlayerInf>().typePlayerColor)
        {
            Debug.LogError("Da va cham voi player");
            int child = collision.transform.childCount;
            GameObject buildFill = collision.gameObject.transform.GetChild(child - 1).gameObject;
            buildFill.transform.SetParent(null);    
            ChangeColor((int)collision.transform.GetComponent<PlayerInf>().typePlayerColor);
            buildFill.GetComponent<Block>().AppearAgain();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.childCount > 0 && (int)typeBlockColor != (int)other.transform.GetComponent<PlayerInf>().typePlayerColor)
        {
            Debug.LogError("Da va cham voi player");
            int child = other.transform.childCount;
            GameObject buildFill = other.gameObject.transform.GetChild(child - 1).gameObject;
            buildFill.transform.SetParent(null);
            ChangeColor((int)other.transform.GetComponent<PlayerInf>().typePlayerColor);
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
