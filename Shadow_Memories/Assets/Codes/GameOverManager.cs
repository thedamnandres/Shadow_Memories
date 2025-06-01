using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ActivarGameOver()
    {
        Debug.Log("Se activó el menú Game Over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal"); // Asegúrate de que esa escena exista
    }
    
            void Start()
        {
            gameOverPanel.SetActive(false);
        }


  

}
