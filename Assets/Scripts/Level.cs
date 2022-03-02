using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : Singleton<Level>
{
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _levelProgress;
   public void RestartTheGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
   [Button]
   public void NextLevel()
   {
      var level = SceneManager.GetActiveScene().buildIndex;
      level++;
      level = level % SceneManager.sceneCountInBuildSettings;
      SceneManager.LoadScene(level);
   }
    [Button]
    public void ControlMovementAndPanel()
    {
        ForwardMovement.Instance._canMove = false;
        _victoryScreen.SetActive(true);
        _levelProgress.SetActive(false);   
    }
}
