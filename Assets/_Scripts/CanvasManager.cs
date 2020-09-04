using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [Header("Hud")]
    public GameObject hud;
    public TextMeshProUGUI coinCount;

    [Header("Loose Canvas")]
    public GameObject looseCanvas;
    public TextMeshProUGUI looseText;
    public TextMeshProUGUI looseTextPoints;
    public GameObject looseBG;

    public void increasePoints()
    {
        PlayerController.Instance.points += 1;

        coinCount.text = PlayerController.Instance.points.ToString();

        LeanTween.scale(coinCount.gameObject, Vector3.one * 1.4f, 0.4f).setEaseInBack();
        LeanTween.scale(coinCount.gameObject, Vector3.one, 0.5f).setEaseOutBounce().setDelay(0.4f);
    }

    public void looseScreen()
    {
        looseText.gameObject.transform.localScale = Vector3.one * 0.8f;
        looseTextPoints.gameObject.transform.localScale = Vector3.one * 0.8f;

        hud.SetActive(false);
        looseCanvas.SetActive(true);

        LeanTween.scale(looseText.gameObject, Vector3.one, 1).setEaseOutBounce();

        

        LeanTween.scale(looseTextPoints.gameObject, Vector3.one * 1.2f, 2).setEaseOutQuad();
        LeanTween.value(looseTextPoints.gameObject, 0, PlayerController.Instance.points, 2).setOnUpdate((float val) =>
         {
             int p = (int)val;
             looseTextPoints.text = p.ToString();
         }).setEaseOutQuad();

        LeanTween.alpha(looseBG, 20f, 1);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void backbtn()
    {
        // Load Main Menu Scene
        looseCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
