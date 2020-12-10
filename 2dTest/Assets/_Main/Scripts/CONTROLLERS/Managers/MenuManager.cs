using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonHelp;

    [SerializeField] private string gameSceneName;
    [SerializeField] private TextMeshProUGUI title;

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject mainMenu;

    float timeToPlay = 1f;
    float currentTimeToPlay;

    bool canCount;

    private void Awake()
    {
        buttonHelp.onClick.AddListener(OnClickHelpHandler);
        
        buttonPlay.onClick.AddListener(OnClickHandler);
        
    }

    private void Start()
    {
        optionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    void OnClickHandler()
    {
        canCount = true;

        title.text = "GO!";
    }

    void OnClickHelpHandler()
    {
        optionsMenu.SetActive(true);

        mainMenu.SetActive(false);
    }

    void Update()
    {
        if(canCount)
        {
            currentTimeToPlay += Time.deltaTime;

            if (currentTimeToPlay >= timeToPlay)
            {
                SceneManager.LoadScene(gameSceneName);
            }
                
        }
    }
}
