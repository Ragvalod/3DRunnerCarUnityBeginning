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

    // TODO ����� ������� ������ ������ ���������� - ������
    public void AddAchievement()
    {
        int money = PlayerPrefs.GetInt("money"); //�������� ����� ���������� ����� 
        money += moneyAdd;                             //����������� ��� �� �������� ������� ��� ���� ����������
        PlayerPrefs.SetInt("money", money);      //��������� ����� �������� � �������
        isProgres = true;                        //��������� ��� �� �������� ��������������
        PlayerPrefs.SetInt("isProgres", isProgres ? 1 : 0);
        AchievementCompleted();//��������� ����� �������� � �������
    }
    // TODO ����� ������� ������ ������ ���������� - �����

    // TODO ����� ��������� ���������� - ������
    public void AchievementCompleted()
    {
        if (totalMoney >= moneyAdd && !isProgres)
        {

            buttProgres.interactable = true; // ���� ����� ������ ������ �������� ��� �������������� � ���
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
    // TODO ����� ��������� ���������� - �����
}
