using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GUIController : MonoBehaviour
{
    public SpiderController spider;
    public TextMesh gameOverText;


    private void Start()
    {
        if (gameOverText == null)
        {
             gameOverText = GetComponentInChildren<TextMesh>();
        }
    }

    private void Update()
    {
        onFall();
    }
    void onFall()
    {
       if(spider.isDead)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
