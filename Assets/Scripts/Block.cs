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

            Vector3 pos = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y + child * 0.2f, other.transform.localPosition.z - 0.8f);
            
            transform.SetParent(other.transform);
            transform.SetPositionAndRotation(pos, other.transform.localRotation);
        }
    }
    public void AppearAgain()
    {
        transform.position = posStar;
    }
}
