using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyMenu : MonoBehaviour
{
    [SerializeField] private int money; //Переменная общего счета денег
    public int totalMoney; //
    public TextMeshPro textMoney;
    
    // TODO: Метод добавления монеток - начало
    public void ButtonClick()
    {
        money++;
        totalMoney++;
        PlayerPrefs.SetInt("money", money); // Сохраняем прогресс игры на устройстве
        PlayerPrefs.SetInt("total_money", totalMoney); // Сохраняем прогресс игры на устройстве
        
    }
    // TODO: Метод добавления монеток - конец

    // TODO: Метод перехода в окно достижений - начал
    public void ToMenuProgres()
    {
        SceneManager.LoadScene("SampleScene 1", LoadSceneMode.Single);        
    }
    // TODO: Метод перехода в окно достижений - конец

    // TODO: Метод автоматического начисления очков - начал
    public void AvtoAddMoney()
    {
        bool isOn = PlayerPrefs.GetInt("isProgres") == 1 ? true : false;
        if (isOn)                       //Если кнопка была активирована
            StartCoroutine(IdleFarm());         //Перезапускаем цикл автоматического начисления очков
    }
    // TODO: Метод автоматического начисления очков - конец

    // TODO Метод автоматического увеличения денег - начало
    IEnumerator IdleFarm()
    {
        if (PlayerPrefs.GetInt("isProgres") == 1) { 
        yield return new WaitForSeconds(2); //Повторять через указанное число секунд
        money++;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(money);

        StartCoroutine(IdleFarm());
        }       //Перезапускаем цикл
    }
    // TODO Метод автоматического увеличения денег - конец

    // Start is called before the first frame update
    void Start()
    {
              
        money = PlayerPrefs.GetInt("money"); // Зогружаем сохраненное количество денег в нашу переменную
        totalMoney = PlayerPrefs.GetInt("total_money"); // Зогружаем сохраненное количество денег в нашу переменную
        AvtoAddMoney();
    }

    public void ResetMoney()
    {
        money = 0;
        totalMoney = 0;
        PlayerPrefs.SetInt("money", money); // Сохраняем прогресс игры на устройстве
        PlayerPrefs.SetInt("total_money", totalMoney); // Сохраняем прогресс игры на устройстве
        PlayerPrefs.SetInt("isProgres", 0);
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = PlayerPrefs.GetInt("money").ToString();
    }
}
