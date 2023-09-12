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
    //Переменные относятся к бонусам
    public int[] costBonus;         //Массив для хранения стоимости бонусов
    public Text[] costBonusShow;    //Массив для вывода текста стоимости бонусов
    private int clickScore = 1;     //переменная хранящая количество очков получаемых за один клик
     
    //Переменные относятся к магазину
    public int[] costInMarcket; //Массив для хранения стоимости бонусов
    public Text[] costInMarcketShow; //Массив для вывода текста стоимости бонусов
    //private int clickScore = 1; //переменная хранящая количество очков получаемых за один клик


    public void Start()
    {
        onClikcCloseShopOrBonus();
        score = PlayerPrefs.GetInt("money");
    }

    private void Update()
    {
        textScore.text = score + "$";
    }

    //Метод обрабатываемый нажатие кропки по экрану (для увеличения количества денег)
    public void onClickBtnScore()
    {
        score += clickScore;
        //textScore.text = score + "$";
        PlayerPrefs.SetInt("money", score);
    }

    //Обработчик нажатия кнопки для вызова панели магазина
    public void onClikcBtnShop()
    {
        zoomToZofObject(DISTANS_ON_MENU);
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    //Обработчик нажатия кнопки для вызова панели бонусов
    public void onClikcBtnBonus()
    {
        zoomToZofObject(DISTANS_ON_MENU);
        bonusPanel.SetActive(!bonusPanel.activeSelf);
    }

    //Обработчик нажатия кнопки для закрытия панели бонусов и магазина
    public void onClikcCloseShopOrBonus()
    {
        zoomToZofObject(DISTANS_OFF_MENU);
        bonusPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    //Метод отдаления от обьекта по оси Z
    private void zoomToZofObject(long distans)
    {        
        mainCamera.transform.position = cameraRotation.transform.position;
        mainCamera.transform.Translate(0, 0, -distans);
    } 
   
    //Метод покупки улучшений
    public void OnClickBuyBonus()
    {
        if(score >= costBonus[0]) //если денег хватает, то покупаем бонус
        {
            score -= costBonus[0]; //Отнимаем деньги за бонус
            PlayerPrefs.SetInt("money", score);
            costBonus[0] *= 2;   //Увеличиваем стоимость бонуса в два раза
            costBonusShow[0].text = costBonus + "$";   //Покажем новую цену
            clickScore *= 2;   //Увеличиваем количество майнинга монет в два раза

        }
    }
    
    //Метод покупки улучшений
    public void OnClickBuyInMarcet()
    {
        if(score >= costInMarcket[0]) //если денег хватает, то покупаем бонус
        {
            score -= costInMarcket[0]; //Отнимаем деньги за бонус
            //costBonus[0] *= 2;   //Увеличиваем стоимость бонуса в два раза
            //costBonusShow[0].text = costBonus + "$";   //Покажем новую цену
            //clickScore *= 2;   //Увеличиваем количество майнинга монет в два раза

        }
    }
    
}

//Создаем отдельный класс для сохранения состояния игры в json файл
public class Save
{
    public int score;           //общее количество очков
    public int clickScore;      //количество очков, которое начислыется за один клик
    public int[] costInMarcket;      //сколько стоит вещь в магазине
    public int[] costBonys;     //сколько очков приносит определенный бонус
}