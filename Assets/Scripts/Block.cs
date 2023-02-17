using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] TypeBlock typeBlockColor;
    Vector3 posStar;
    private void Start()
    {
        posStar = transform.position;

    }
    enum TypeBlock
    {
        BlockRed,
        BlockBlue,
        BlockGreen,
        BlockYellow

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = (int)(transform.position.x);
            int j = (int)(transform.position.z);
            //GameManager.GetInstance().sa[x,z] = 0;
            //this.gameObject.SetActive(false);
            int child = other.transform.childCount;         
            GameManager.GetInstance().sa[i, j] = 0;
            gameObject.transform.SetLocalPositionAndRotation(new Vector3(other.transform.position.x - 0.5f,other.transform.position.y + child * 0.2f, other.transform.position.z), other.transform.rotation);
            gameObject.transform.SetParent(other.transform);
        }
    }
    public void AppearAgain()
    {
        transform.position = posStar;
    }
}
