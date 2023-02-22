using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Type color block")]
    public TypeBlock typeBlockColor = TypeBlock.None;
    Vector3 posStar;
    public List<Material> colorMaterials;
    private void Start()
    {
        posStar = transform.position;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (int)typeBlockColor == (int)other.GetComponent<PlayerInf>().typePlayerColor)
        {
            int i = (int)(transform.position.x);
            int j = (int)(transform.position.z);         
            int child = other.transform.childCount;
            GameManager.GetInstance().sa[i, j] = 0;
                     
            Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y + child * 0.2f, other.transform.position.z - 0.8f);
            transform.position = pos;
            transform.SetParent(other.transform);
           
            switch ((int)typeBlockColor)
            {
                case (int)TypeBlock.BlockRed:
                    GameManager.GetInstance().blockRed.Remove(this.gameObject);
                    break;
                case (int)TypeBlock.BlockBlue:
                    Debug.LogError("Remove");
                    GameManager.GetInstance().blockBlue.Remove(this.gameObject);
                    break;
                case (int)TypeBlock.BlockGreen:
                    GameManager.GetInstance().blockGreen.Remove(this.gameObject);
                    break;
                case (int)TypeBlock.BlockYellow:
                    GameManager.GetInstance().blockYellow.Remove(this.gameObject);
                    break;
                default:
                    break;
            }
            
        }
    }
    public void AppearAgain()
    {
        transform.position = posStar;
        GameManager.GetInstance().blockBlue.Add(this.gameObject);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
