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
    private TimeSpan tS;

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
        //PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        SceneManager.LoadScene(1);        
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

    //Метод расчета денег которие мы заработали за время отсутствия 
    private void OfflineTimeEarnings() {
                
        if(PlayerPrefs.HasKey("LastSession"))
        {
            tS = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(string.Format("Вас небыло {0} дней,{1} часов,{2} минут,{3} секунд", tS.Days, tS.Hours, tS.Minutes, tS.Seconds));
        }
    }

// TODO Два метода которие отрабатывают сварачивание игры - НАЧАЛО

    //Метод работает ТОЛЬКО!!! на андроиде. Вызывается при сварачивании окна игры.
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        //Если мы поставили на паузу
        if (pause) 
        {
            //Сохраним текущее значение даты в файл
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());        
        }
    }

    //Метод работает ТОЛЬКО!!! на в редакторе UNITY. Вызывается при сварачивании окна игры.
#else
    private void OnApplicationQuit()
    {
        //Сохраним текущее значение даты в файл
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif
    // TODO Два метода которие отрабатывают сварачивание игры - КОНЕЦ

    // Start is called before the first frame update
    void Start()
    { 
        
        money = PlayerPrefs.GetInt("money"); // Зогружаем сохраненное количество денег в нашу переменную
        totalMoney = PlayerPrefs.GetInt("total_money"); // Зогружаем сохраненное количество денег в нашу переменную
        OfflineTimeEarnings();
        moneyOffline();  
        AvtoAddMoney(); 
    }

    //Метод расчитывающий количество денег за време отсутствия
    private void moneyOffline()
    {
        bool isOn = PlayerPrefs.GetInt("isProgres") == 1 ? true : false;
        if (isOn)
        {
            money += (int)tS.TotalSeconds;
            totalMoney = money;
            PlayerPrefs.SetInt("money", money); // Сохраняем прогресс игры на устройстве
            PlayerPrefs.SetInt("total_money", totalMoney); // Сохраняем прогресс игры на устройстве
        }
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
        totalMoney = money;
        textMoney.text = PlayerPrefs.GetInt("money").ToString();
    }
}
