
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;


public class CreateRoom : MonoBehaviour
{
    private Button _createRoomBtn;
    public GameObject loadingUI;
    private TextField _userRoomName;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _createRoomBtn = root.Q<Button>(name: "CreateRoomBtn");
        _createRoomBtn.clicked += CreateRoomBtnOnClicked;
        _userRoomName = root.Q<TextField>(name: "UserRoomName");

    }
    private void CreateRoomBtnOnClicked()
    {
        string usetInput = _userRoomName.value;
        if (string.IsNullOrEmpty(usetInput)) return;

        PhotonNetwork.CreateRoom(usetInput);
        gameObject.SetActive(false);
        loadingUI.SetActive(true);

    }
}