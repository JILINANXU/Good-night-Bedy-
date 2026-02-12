using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public GameObject bk1, bk2;
    public GameObject[] music;
    public SpriteRenderer black;
    Color color = new Color(0f, 0f, 0f, 1f);
    // Start is called before the first frame update
    private void Awake()
    {
        music[0].SetActive(true);
    }
    void Start()
    {
        black.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a > 0f)
        {
            color.a -= 0.05f;
            black.color = color;
        }
    }

    public void StartGame()
    {
        bk1.SetActive(false);
        bk2.SetActive(true);
        music[0].SetActive(false);
        music[1].SetActive(true);
        StartCoroutine(StartWait(3f));
    }
    public void ContinueGame()
    {
        bk1.SetActive(false);
        bk2.SetActive(true);
        music[0].SetActive(false);
        music[1].SetActive(true);
        StartCoroutine(ContinueWait(3f));
    }
    IEnumerator StartWait(float delay)
    {
        //Debug.Log("Starting Game...");
        yield return new WaitForSeconds(delay);
        PlayerPrefs.SetInt("day", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("gap");
        //Debug.Log("Starting Game...");
    }
    IEnumerator ContinueWait(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day",0));
        PlayerPrefs.Save();
        SceneManager.LoadScene("gap");
    }
}
