using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] TypeBlock typeBlockColor;
    enum TypeBlock
    {
        BlockRed,
        BlockBlue,
        BlockGreen,
        BlockYellow

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
