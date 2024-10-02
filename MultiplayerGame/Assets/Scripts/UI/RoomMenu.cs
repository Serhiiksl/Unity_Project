
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomMenu : MonoBehaviour
{

    private Button _startGameBtn;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Label roomName = root.Q<Label>(name: "roomName");
        roomName.text = "ʳ����� ���������: " + PhotonNetwork.CurrentRoom.Name;

        _startGameBtn = root.Q<Button>("StartGameBtn");
        _startGameBtn.clicked += StartGameBtnOnClicked;

        if(!PhotonNetwork.IsMasterClient)
        {
            _startGameBtn.SetEnabled(false);
        }
    }

    private void StartGameBtnOnClicked()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
