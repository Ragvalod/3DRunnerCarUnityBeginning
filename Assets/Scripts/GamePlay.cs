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

    //Метод обрабатываемый нажатие кропки по экрану (для увеличения количества денег)
    public void onClickBtnScore()
    {
        score++;
        //textScore.text = score + "$";
        PlayerPrefs.SetInt("money", score);
    }

    //Обработчик нажатия кнопки для вызова панели магазина
    public void onClikcBtnShop()
    {
        zoomToZofObject(500);
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    //Обработчик нажатия кнопки для вызова панели бонусов
    public void onClikcBtnBonus()
    {
        zoomToZofObject(500);
        bonusPanel.SetActive(!bonusPanel.activeSelf);
    }

    //Обработчик нажатия кнопки для вызова панели бонусов
    public void onClikcCloseShopOrBonus()
    {
        zoomToZofObject(120);
        bonusPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    //Метод отдаления от обьекта по оси Z
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

