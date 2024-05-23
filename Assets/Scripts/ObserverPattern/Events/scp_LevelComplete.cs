using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_LevelComplete : MonoBehaviour
{
    //Stores the game event script in this variable
    public scp_GameEvent gameEvent;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Defaults the cursor to visible
            Cursor.visible = true;
        }
    }
}
