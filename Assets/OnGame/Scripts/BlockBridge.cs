using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBridge : MonoBehaviour
{
    [Header("Type color block")]
    public TypeBlock typeBlockColor = TypeBlock.None;
    public List<Material> colorMaterials;
    [SerializeField] private PlayerController playerController;
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
        transform.GetComponent<MeshRenderer>().material = colorMaterials[color];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.GetComponent<PlayerController>().containBlock.childCount > 0 && (int)typeBlockColor != (int)collision.transform.GetComponent<PlayerController>().typePlayerColor)
        {
            int child = playerController.containBlock.childCount;
            GameObject buildFill = playerController.blockOfPlayer[child - 1].gameObject;
            playerController.blockOfPlayer.Remove(playerController.blockOfPlayer[child - 1]);
            GameManager.GetInstance().ReturnBlock(buildFill);
            ChangeColor((int)collision.transform.GetComponent<PlayerController>().typePlayerColor);
            
            buildFill.GetComponent<Block>().AppearAgain();
        }
        if (collision.gameObject.CompareTag("BotPlayer") && collision.transform.GetComponent<BotPlayer>().containBlock.childCount > 0 && (int)typeBlockColor != (int)collision.transform.GetComponent<BotPlayer>().typePlayerColor)
        {
            int child = collision.transform.GetComponent<BotPlayer>().containBlock.childCount;
            GameObject buildFill = collision.transform.GetComponent<BotPlayer>().blockOfPlayer[child - 1].gameObject;
            collision.transform.GetComponent<BotPlayer>().blockOfPlayer.Remove(collision.transform.GetComponent<BotPlayer>().blockOfPlayer[child - 1]);
            GameManager.GetInstance().ReturnBlock(buildFill);
            ChangeColor((int)collision.transform.GetComponent<BotPlayer>().typePlayerColor);
            
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
