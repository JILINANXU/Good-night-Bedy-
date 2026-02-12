using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class allOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diaLog;
    public Text dialog;
    public TextAsset[] dialogFile;
    List<string> textList = new List<string>();
    public int index;
    public SpriteRenderer black;
    Color color = new Color(0f, 0f, 0f, 1f);
    void Start()
    {
        GetTextFromFile(dialogFile[0]);
        index = 0;
        dialog.text = textList[index];
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
            diaLog.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R)&&diaLog.activeSelf)
        {
            index++;
            if (index >= textList.Count)
            {
                PlayerPrefs.SetInt("day", 5);
                SceneManager.LoadScene("mainMenu");
            }
            dialog.text = textList[index];

        }
        
    }

    public void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split("@");
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }
}
