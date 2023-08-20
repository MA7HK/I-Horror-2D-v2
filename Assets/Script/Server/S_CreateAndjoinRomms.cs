using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class S_CreateAndjoinRomms : MonoBehaviourPunCallbacks
{
    public InputField IF_CreateRoom;
    public InputField IF_JoinRoom;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(IF_CreateRoom.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(IF_JoinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("I_HorrorScene");
    }
}
