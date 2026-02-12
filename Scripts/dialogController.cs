using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dialog;
    public TextAsset[] dialogFile;
    public gameController gc;
    List<string> textList = new List<string>();
    public int index;
    private bool over = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            GetTextFromFile(dialogFile[gc.textFileId]);
            index = 0;
            dialog.text = textList[index];
            over = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            index++;
            if (index >= textList.Count)
            {
                index = 0;
                over = true;
                gameObject.SetActive(false);
            }
            dialog.text = textList[index];
            
        }
    }

    public void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split("@");
        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }
}
