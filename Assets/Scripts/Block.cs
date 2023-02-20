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
            //GameManager.GetInstance().sa[x,z] = 0;
            //this.gameObject.SetActive(false);
            int child = other.transform.childCount;
            GameManager.GetInstance().sa[i, j] = 0;
            gameObject.transform.SetLocalPositionAndRotation(new Vector3(other.transform.position.x - 0.5f, other.transform.position.y + child * 0.2f, other.transform.position.z), other.transform.rotation);
            gameObject.transform.SetParent(other.transform);
        }
    }
    public void AppearAgain()
    {
        transform.position = posStar;
    }
}
