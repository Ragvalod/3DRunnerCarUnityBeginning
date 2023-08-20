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
    

    public void Start()
    {
        score = PlayerPrefs.GetInt("money");
    }

    //����� �������������� ������� ������ �� ������ (��� ���������� ���������� �����)
    public void onClickBtnScore()
    {
        score++;
        //textScore.text = score + "$";
        PlayerPrefs.SetInt("money", score);
    }

    //���������� ������� ������ ��� ������ ������ ��������
    public void onClikcBtnShop()
    {
        zoomToZofObject(500);
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    //���������� ������� ������ ��� ������ ������ �������
    public void onClikcBtnBonus()
    {
        zoomToZofObject(500);
        bonusPanel.SetActive(!bonusPanel.activeSelf);
    }

    //���������� ������� ������ ��� ������ ������ �������
    public void onClikcCloseShopOrBonus()
    {
        zoomToZofObject(120);
        bonusPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    //����� ��������� �� ������� �� ��� Z
    private void zoomToZofObject(long distans)
    {
        
        mainCamera.transform.position = cameraRotation.transform.position;
        mainCamera.transform.Translate(0, 0, -distans);
    }

    private void Update()
    {
        textScore.text = score + "$";
    }
}

