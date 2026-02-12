using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gap : MonoBehaviour
{
    public Text dayText;
    public SpriteRenderer black;
    Color color = new Color(0f, 0f, 0f, 1f);
    // Start is called before the first frame update
    private void Awake()
    {
        int night = PlayerPrefs.GetInt("day", 0);
        dayText.text = "ตฺ " + night + " าน";
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (color.a > 0f)
        {
            color.a -= 0.005f;
            black.color = color;
        }
        else
        {
            StartCoroutine(NextDay(5f));
        }
    }
    IEnumerator NextDay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("mainGame");
    }
}
