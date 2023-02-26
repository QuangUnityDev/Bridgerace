using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProcessBridge : MonoBehaviour
{
    public GameObject cubeCheckPlayer;
    public PlayerController player;
    public List<BlockBridge> listBlockBridge;
    public int bridgeFloor;
    public CheckFloor checkFloor;

    void Update()
    {

        for (int i = 0; i < listBlockBridge.Count; i++)
        {
            if (checkFloor.isPass && checkFloor.indexFloor == bridgeFloor)
            {
                cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[listBlockBridge.Count - 1].transform.localPosition.x, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[listBlockBridge.Count - 1].transform.localPosition.z);               
                return;
            }
            if ((int)listBlockBridge[i].typeBlockColor != (int)player.typePlayerColor && !BlockBridge.isOnBridge) //CheckPlayerLaXuongCauVaCoBLockCauNaoKhacVoiPlayerThiSeSetLaiViTriChan
            {
                if (player.blockOwner > 0)
                {
                    cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[i].transform.localPosition.x + 1.1f, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[i].transform.localPosition.z);
                }
                else cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[i].transform.localPosition.x, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[i].transform.localPosition.z);
                return;
            }

            if ((int)listBlockBridge[i].typeBlockColor == (int)player.typePlayerColor && BlockBridge.isOnBridge)
            {
                if (player.blockOwner > 0)
                {
                    cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[i].transform.localPosition.x + 4.4f, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[i].transform.localPosition.z);
                }
                else
                {

                    if ((int)listBlockBridge[listBlockBridge.Count - 1].typeBlockColor == (int)player.typePlayerColor)
                    {
                        cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[i].transform.localPosition.x + 11.11f, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[i].transform.localPosition.z);
                    }
                    else
                        cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[i].transform.localPosition.x + 1.1f, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[i].transform.localPosition.z);
                }
            }

            if (player.blockOwner > 0 && !BlockBridge.isOnBridge)
            {
                cubeCheckPlayer.transform.localPosition = new Vector3(listBlockBridge[0].transform.localPosition.x + 1.1f, cubeCheckPlayer.transform.localPosition.y, listBlockBridge[0].transform.localPosition.z);
            }
        }



    }
}
