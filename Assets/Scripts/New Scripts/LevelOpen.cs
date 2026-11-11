using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOpen : MonoBehaviour
{
   public int SceneToOpen = 0;

   public void SceneSwitch()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToOpen);
    }
}
