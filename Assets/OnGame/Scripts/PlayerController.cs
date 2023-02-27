using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Charecter
{
    public VariableJoystick variableJoystick;

    public void FixedUpdate()
    {
        if (!GameManager.GetInstance().isStartGame) return;
        blockOwner = containBlock.childCount;
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        if(Mathf.Abs(variableJoystick.Vertical) > 0 || Mathf.Abs(variableJoystick.Horizontal) > 0)
        {
            ChangeAnim("Run");
        }
        else ChangeAnim("Idle");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block")) { 
        if ((int)typePlayerColor == (int)other.GetComponent<Block>().typeBlockColor)
        {           
            int child = containBlock.transform.childCount;
            other.transform.SetParent(containBlock.transform);
            blockOfPlayer.Add(other.gameObject);
            other.transform.SetLocalPositionAndRotation(new Vector3(containBlock.transform.localPosition.x, containBlock.transform.localPosition.y + 0.3f * child, containBlock.transform.localPosition.z), containBlock.localRotation);
            GameManager.GetInstance().RemoveBlock(other.gameObject);
            }
        }
    }
}
