using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject title;



    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(title, Vector3.one, 2f).setEaseOutBack().setLoopPingPong();
    }

    
        // Load game scene 
    public void playbtn()
    {

        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
            PlayerController.Instance.points = 0;
            PlayerController.Instance.loosed = false;
        }

        if (CanvasManager.Instance != null)
        {
            
            CanvasManager.Instance.coinCount.text = "0";
            CanvasManager.Instance.hud.SetActive(true);
        }

        SoundManager.Instance.Play("Play");

        SceneManager.LoadScene(1);
    }

    public void creditsbtn()
    {
        Application.OpenURL("https://linktr.ee/freddynewton");
    }

    public void exitbtn()
    {
        Application.Quit();
    }
}
