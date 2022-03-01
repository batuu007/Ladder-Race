using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : Singleton<Level>
{
   public void GameOver()
   {
      
   }

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
}
