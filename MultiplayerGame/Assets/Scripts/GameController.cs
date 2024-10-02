using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourPunCallbacks
{
   private static GameController _game;
    private void Start()
    {   if(_game != null)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        _game = this;
        
    }

    // Update is called once per frame
    public override void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;

    }

    private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if(scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, Quaternion.identity);
        }
    }
}
