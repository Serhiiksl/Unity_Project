using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _photonView;
    private static Vector3 one = new Vector3(9f, 1f, -9f), two = new Vector3(-9f, 1f, 13f), three = new Vector3(-9f, 1f, -9f), four = new Vector3(9f, 1f, 18f);
    private Vector3[] arr = new[] {one, two, three, four};
    private void Start()
    {   _photonView = GetComponent<PhotonView>();
        if(_photonView.IsMine)
            CreatePlayer();
    }
    private void CreatePlayer()
    {
        Vector3 pos = arr[Random.Range(0,arr.Length)];
        PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
    }
}
