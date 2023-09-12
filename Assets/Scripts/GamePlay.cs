using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private int score;
    public TextMeshPro textScore;

    public GameObject shopPanel, bonusPanel, mainCamera, cameraRotation;

    private const long DISTANS_ON_MENU = 500;
    private const long DISTANS_OFF_MENU = 140;

    // private Vector3 _vector3 = new Vector3();
    //���������� ��������� � �������
    public int[] costBonus;         //������ ��� �������� ��������� �������
    public Text[] costBonusShow;    //������ ��� ������ ������ ��������� �������
    private int clickScore = 1;     //���������� �������� ���������� ����� ���������� �� ���� ����
     
    //���������� ��������� � ��������
    public int[] costInMarcket; //������ ��� �������� ��������� �������
    public Text[] costInMarcketShow; //������ ��� ������ ������ ��������� �������
    //private int clickScore = 1; //���������� �������� ���������� ����� ���������� �� ���� ����


    public void Start()
    {
        onClikcCloseShopOrBonus();
        score = PlayerPrefs.GetInt("money");
    }

    private void Update()
    {
        textScore.text = score + "$";
    }

    //����� �������������� ������� ������ �� ������ (��� ���������� ���������� �����)
    public void onClickBtnScore()
    {
        score += clickScore;
        //textScore.text = score + "$";
        PlayerPrefs.SetInt("money", score);
    }

    //���������� ������� ������ ��� ������ ������ ��������
    public void onClikcBtnShop()
    {
        zoomToZofObject(DISTANS_ON_MENU);
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    //���������� ������� ������ ��� ������ ������ �������
    public void onClikcBtnBonus()
    {
        zoomToZofObject(DISTANS_ON_MENU);
        bonusPanel.SetActive(!bonusPanel.activeSelf);
    }

    //���������� ������� ������ ��� �������� ������ ������� � ��������
    public void onClikcCloseShopOrBonus()
    {
        zoomToZofObject(DISTANS_OFF_MENU);
        bonusPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    //����� ��������� �� ������� �� ��� Z
    private void zoomToZofObject(long distans)
    {        
        mainCamera.transform.position = cameraRotation.transform.position;
        mainCamera.transform.Translate(0, 0, -distans);
    } 
   
    //����� ������� ���������
    public void OnClickBuyBonus()
    {
        if(score >= costBonus[0]) //���� ����� �������, �� �������� �����
        {
            score -= costBonus[0]; //�������� ������ �� �����
            PlayerPrefs.SetInt("money", score);
            costBonus[0] *= 2;   //����������� ��������� ������ � ��� ����
            costBonusShow[0].text = costBonus + "$";   //������� ����� ����
            clickScore *= 2;   //����������� ���������� �������� ����� � ��� ����

        }
    }
    
    //����� ������� ���������
    public void OnClickBuyInMarcet()
    {
        if(score >= costInMarcket[0]) //���� ����� �������, �� �������� �����
        {
            score -= costInMarcket[0]; //�������� ������ �� �����
            //costBonus[0] *= 2;   //����������� ��������� ������ � ��� ����
            //costBonusShow[0].text = costBonus + "$";   //������� ����� ����
            //clickScore *= 2;   //����������� ���������� �������� ����� � ��� ����

        }
    }
    
}

//������� ��������� ����� ��� ���������� ��������� ���� � json ����
public class Save
{
    public int score;           //����� ���������� �����
    public int clickScore;      //���������� �����, ������� ����������� �� ���� ����
    public int[] costInMarcket;      //������� ����� ���� � ��������
    public int[] costBonys;     //������� ����� �������� ������������ �����
}