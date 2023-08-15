using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Progres : MonoBehaviour
{

    public int money;
    public int totalMoney;
    [SerializeField] bool isProgres;

    public string[] arrayTitles;
    public Sprite[] arraySprites;
    public GameObject button;
    public GameObject content;

    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;

    
    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetInt("money"); // Зогружаем сохраненное количество денег в нашу переменную
        totalMoney = PlayerPrefs.GetInt("total_money");
        isProgres = PlayerPrefs.GetInt("isProgres") == 1 ? true : false;

        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = Vector3.zero;
        _group = GetComponent<VerticalLayoutGroup>();
        setAchievs();


        if (isProgres)
        {
            StartCoroutine(IdleFarm());
        }

        //AchievementCompleted();

    }

    // TODO Метод очистки списка - начало
    private void RemoveList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }
    // TODO Метод очистки списка - конец

    // TODO Метод непосредственно размещения кнопок достижений на экране - начало
    void setAchievs()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = Vector3.zero;
        RemoveList();
        if (arrayTitles.Length > 0)
        {
            //Создаем экземпляр кнопки достижения
            var buttonAchi = Instantiate(button, transform);
            //Определяем высоту кнопки
            var buttonAchiHeight = buttonAchi.GetComponent<RectTransform>().rect.height;
            var rectTransfCustom = GetComponent<RectTransform>();
            rectTransfCustom.sizeDelta = new Vector2(rectTransfCustom.rect.width, buttonAchiHeight * arrayTitles.Length);
            Destroy(buttonAchi);

            for (var i = 0; i < arrayTitles.Length; i++)
            {
                var buttonAchievs = Instantiate(button, transform);
                buttonAchievs.GetComponentInChildren<Text>().text = arrayTitles[i] + " #" + i;
                buttonAchievs.GetComponentsInChildren<Image>()[1].sprite = arraySprites[i];
                var i1 = i;
                buttonAchievs.GetComponent<Button>().onClick.AddListener(() => GetAchievement(i1));
                list.Add(buttonAchievs);
            }
        }
    }
    // TODO Метод непосредственно размещения кнопок достижений на экране - конец

    // TODO Метод реализующий нажатие на кнопку достижения - начало
    void GetAchievement(int id)
    {
        switch (id)
        {
            case 0:
                Debug.Log(id);
                IdleFarm();
                break;
            case 1:
                Debug.Log(id);
                money += 100;
                totalMoney = money;
                PlayerPrefs.SetInt("money", money);
                PlayerPrefs.SetInt("total_money", totalMoney);
                break;
            case 2:
                Debug.Log(id);
                money += 1000;
                totalMoney = money;
                PlayerPrefs.SetInt("money", money);
                PlayerPrefs.SetInt("total_money", totalMoney);
                break;
        }
    }
    // TODO Метод реализующий нажатие на кнопку достижения - конец

    //// TODO Метод нажатия кнопки выбора достижения - начало
    //public void PresedButtonAchievement()
    //{
    //    int money = PlayerPrefs.GetInt("money"); //Получаем общее количество денег 
    //    money += 10;                             //Увеличиваем его на значение которое нам дает достижение
    //    PlayerPrefs.SetInt("money", money);      //Сохраняем новое значание в системе
    //    isProgres = true;                        //Указываем что мы получили вознагрождение
    //    PlayerPrefs.SetInt("isProgres", isProgres ?  1 : 0);
    //    AchievementCompleted();//Сохраняем новое значание в системе
    //}
    //// TODO Метод нажатия кнопки выбора достижения - конец

    //// TODO Метод полечения достижения - начало
    //public void AchievementCompleted()
    //{               
    //    if (totalMoney >= 10 && !isProgres)
    //    {
            
    //        buttProgres.interactable = true; // Этот метод делает кнопку активной для взаимодействия с ней
    //        //buttonText.SetText("Gjkexbnm yfuhfle");
    //    }
    //    else
    //    {
    //        buttProgres.interactable = false;

    //        if(isProgres)                       //Если кнопка была активирована
    //        StartCoroutine(IdleFarm());         //Перезапускаем цикл автоматического начисления очков
            
    //    }
    //}
    //// TODO Метод полечения достижения - конец

    // TODO Метод автоматического увеличения денег - начало
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(2); //Повторять через указанное число секунд
        money++;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(money);
        StartCoroutine(IdleFarm());         //Перезапускаем цикл
    }
    // TODO Метод автоматического увеличения денег - конец


    // TODO Метод возврата назад - начало
    public void OnBackPresed()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    // TODO Метод возврата назад - конец

    // Update is called once per frame
    void Update()
    {
        
    }
}
