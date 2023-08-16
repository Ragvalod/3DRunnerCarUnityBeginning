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
    private TimeSpan tS;

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
        //PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        SceneManager.LoadScene(1);        
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

    //����� ������� ����� ������� �� ���������� �� ����� ���������� 
    private void OfflineTimeEarnings() {
                
        if(PlayerPrefs.HasKey("LastSession"))
        {
            tS = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(string.Format("��� ������ {0} ����,{1} �����,{2} �����,{3} ������", tS.Days, tS.Hours, tS.Minutes, tS.Seconds));
        }
    }

// TODO ��� ������ ������� ������������ ������������ ���� - ������

    //����� �������� ������!!! �� ��������. ���������� ��� ������������ ���� ����.
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        //���� �� ��������� �� �����
        if (pause) 
        {
            //�������� ������� �������� ���� � ����
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());        
        }
    }

    //����� �������� ������!!! �� � ��������� UNITY. ���������� ��� ������������ ���� ����.
#else
    private void OnApplicationQuit()
    {
        //�������� ������� �������� ���� � ����
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif
    // TODO ��� ������ ������� ������������ ������������ ���� - �����

    // Start is called before the first frame update
    void Start()
    { 
        
        money = PlayerPrefs.GetInt("money"); // ��������� ����������� ���������� ����� � ���� ����������
        totalMoney = PlayerPrefs.GetInt("total_money"); // ��������� ����������� ���������� ����� � ���� ����������
        OfflineTimeEarnings();
        moneyOffline();  
        AvtoAddMoney(); 
    }

    //����� ������������� ���������� ����� �� ����� ����������
    private void moneyOffline()
    {
        bool isOn = PlayerPrefs.GetInt("isProgres") == 1 ? true : false;
        if (isOn)
        {
            money += (int)tS.TotalSeconds;
            totalMoney = money;
            PlayerPrefs.SetInt("money", money); // ��������� �������� ���� �� ����������
            PlayerPrefs.SetInt("total_money", totalMoney); // ��������� �������� ���� �� ����������
        }
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
        totalMoney = money;
        textMoney.text = PlayerPrefs.GetInt("money").ToString();
    }
}
