using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private GameObject _endGameText;
    //[SerializeField] private GameObject _continueText;

    private void Start()
    {
        _endGamePanel.SetActive(false);
        _endGameText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _endGamePanel.SetActive(true);
            _endGameText.SetActive(true);
            StartCoroutine(LoadMainMenu());
        }
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        //_continueText.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
}
