using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class cshPointer : MonoBehaviour
{
    public Image LoadingBar;
    public GameObject explain;
    private bool IsOn;
    private float barTime = 0.0f;


    public bool IsExpain;
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;
        explain.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //시선 처리 부분
        if (IsOn)
        {
            if (barTime <= 3.0f)
            {
                barTime += Time.deltaTime;
            }
           
            //바가 다 채워지면
            else
            {
                LoadingBar.fillAmount = 0;
                explain.SetActive(true);
                IsExpain = true;
            }

            LoadingBar.fillAmount = barTime / 3.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public void SetGazedAt(bool gazedAt)
    {
        IsOn = gazedAt;
        barTime = 0.0f;

        if (gazedAt)
            Debug.Log("In");
        else
        {
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;

        }
      

    }

}
