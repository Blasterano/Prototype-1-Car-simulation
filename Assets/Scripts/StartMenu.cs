using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
        
    }
    public void Normal()
    {
        SceneManager.LoadScene(1);

    }

    public void Pyramid()
    {
        SceneManager.LoadScene(2);

    }
    public void Oncoming()
    {
        SceneManager.LoadScene(3);

    }
    public void Duel()
    {
        SceneManager.LoadScene(4);

    }
    public void Credits()
    {
        SceneManager.LoadScene(5);

    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
