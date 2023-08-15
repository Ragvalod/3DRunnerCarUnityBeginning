using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllAchievements 
{
    private int totalMoney;
    private Button buttProgres;
    private bool isProgres;
    public TextMeshPro buttonText;
    private int moneyAdd;


    public AllAchievements(int moneyAdd)
    {
        this.moneyAdd = moneyAdd;
    }

    // TODO Метод нажатия кнопки выбора достижения - начало
    public void AddAchievement()
    {
        int money = PlayerPrefs.GetInt("money"); //Получаем общее количество денег 
        money += moneyAdd;                             //Увеличиваем его на значение которое нам дает достижение
        PlayerPrefs.SetInt("money", money);      //Сохраняем новое значание в системе
        isProgres = true;                        //Указываем что мы получили вознагрождение
        PlayerPrefs.SetInt("isProgres", isProgres ? 1 : 0);
        AchievementCompleted();//Сохраняем новое значание в системе
    }
    // TODO Метод нажатия кнопки выбора достижения - конец

    // TODO Метод полечения достижения - начало
    public void AchievementCompleted()
    {
        if (totalMoney >= moneyAdd && !isProgres)
        {

            buttProgres.interactable = true; // Этот метод делает кнопку активной для взаимодействия с ней
            //buttonText.SetText("Gjkexbnm yfuhfle");
        }
        else
        {
            buttProgres.interactable = false;
            //buttonText.SetText("Gjkexbnm");
            //string aaa = "sssss";
            //buttonText.text = aaa;
        }
    }
    // TODO Метод полечения достижения - конец
}
