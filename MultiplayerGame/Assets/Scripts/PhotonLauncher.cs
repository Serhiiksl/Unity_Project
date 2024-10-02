
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{   public static List<string> RoomList = new List<string>();
    public GameObject mainMenu, loading, roomMenu, joinRoom;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() 
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        loading.SetActive(false);
        mainMenu.SetActive(true);
        Debug.Log(message: "Connected to Lobby");
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(message: "Connected to the Room");
        loading.SetActive(false );
        roomMenu.SetActive(true );

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError(message: "Not connected to the Room"+ message);

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        RoomList.Clear();
        foreach(var el in roomList)
        {
            RoomList.Add(el.Name);
        }
        joinRoom.GetComponent<ListOfRooms>().ChangeRooms();
    }

}
