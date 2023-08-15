using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyMenu : MonoBehaviour
{
    [SerializeField] private int money; //���������� ������ ����� �����
    public int totalMoney; //
    public TextMeshPro textMoney;
    
    // TODO: ����� ���������� ������� - ������
    public void ButtonClick()
    {
        money++;
        totalMoney++;
        PlayerPrefs.SetInt("money", money); // ��������� �������� ���� �� ����������
        PlayerPrefs.SetInt("total_money", totalMoney); // ��������� �������� ���� �� ����������
        
    }
    // TODO: ����� ���������� ������� - �����

    // TODO: ����� �������� � ���� ���������� - �����
    public void ToMenuProgres()
    {
        SceneManager.LoadScene("SampleScene 1", LoadSceneMode.Single);        
    }
    // TODO: ����� �������� � ���� ���������� - �����

    // TODO: ����� ��������������� ���������� ����� - �����
    public void AvtoAddMoney()
    {
        bool isOn = PlayerPrefs.GetInt("isProgres") == 1 ? true : false;
        if (isOn)                       //���� ������ ���� ������������
            StartCoroutine(IdleFarm());         //������������� ���� ��������������� ���������� �����
    }
    // TODO: ����� ��������������� ���������� ����� - �����

    // TODO ����� ��������������� ���������� ����� - ������
    IEnumerator IdleFarm()
    {
        if (PlayerPrefs.GetInt("isProgres") == 1) { 
        yield return new WaitForSeconds(2); //��������� ����� ��������� ����� ������
        money++;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(money);

        StartCoroutine(IdleFarm());
        }       //������������� ����
    }
    // TODO ����� ��������������� ���������� ����� - �����

    // Start is called before the first frame update
    void Start()
    {
              
        money = PlayerPrefs.GetInt("money"); // ��������� ����������� ���������� ����� � ���� ����������
        totalMoney = PlayerPrefs.GetInt("total_money"); // ��������� ����������� ���������� ����� � ���� ����������
        AvtoAddMoney();
    }

    public void ResetMoney()
    {
        money = 0;
        totalMoney = 0;
        PlayerPrefs.SetInt("money", money); // ��������� �������� ���� �� ����������
        PlayerPrefs.SetInt("total_money", totalMoney); // ��������� �������� ���� �� ����������
        PlayerPrefs.SetInt("isProgres", 0);
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = PlayerPrefs.GetInt("money").ToString();
    }
}
