using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIScene : MonoBehaviour
{
    private SceneTransition _sceneTransition;
    [SerializeField] private string sceneToLoad;

        void Awake()
    {
       _sceneTransition = new SceneTransition(); 
    }

    public void Loader()
    {
        _sceneTransition.SceneToLoad = sceneToLoad;
    }

}
