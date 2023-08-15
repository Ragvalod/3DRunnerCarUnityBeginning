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
        money = PlayerPrefs.GetInt("money"); // ��������� ����������� ���������� ����� � ���� ����������
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

    // TODO ����� ������� ������ - ������
    private void RemoveList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }
    // TODO ����� ������� ������ - �����

    // TODO ����� ��������������� ���������� ������ ���������� �� ������ - ������
    void setAchievs()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = Vector3.zero;
        RemoveList();
        if (arrayTitles.Length > 0)
        {
            //������� ��������� ������ ����������
            var buttonAchi = Instantiate(button, transform);
            //���������� ������ ������
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
    // TODO ����� ��������������� ���������� ������ ���������� �� ������ - �����

    // TODO ����� ����������� ������� �� ������ ���������� - ������
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
    // TODO ����� ����������� ������� �� ������ ���������� - �����

    //// TODO ����� ������� ������ ������ ���������� - ������
    //public void PresedButtonAchievement()
    //{
    //    int money = PlayerPrefs.GetInt("money"); //�������� ����� ���������� ����� 
    //    money += 10;                             //����������� ��� �� �������� ������� ��� ���� ����������
    //    PlayerPrefs.SetInt("money", money);      //��������� ����� �������� � �������
    //    isProgres = true;                        //��������� ��� �� �������� ��������������
    //    PlayerPrefs.SetInt("isProgres", isProgres ?  1 : 0);
    //    AchievementCompleted();//��������� ����� �������� � �������
    //}
    //// TODO ����� ������� ������ ������ ���������� - �����

    //// TODO ����� ��������� ���������� - ������
    //public void AchievementCompleted()
    //{               
    //    if (totalMoney >= 10 && !isProgres)
    //    {
            
    //        buttProgres.interactable = true; // ���� ����� ������ ������ �������� ��� �������������� � ���
    //        //buttonText.SetText("Gjkexbnm yfuhfle");
    //    }
    //    else
    //    {
    //        buttProgres.interactable = false;

    //        if(isProgres)                       //���� ������ ���� ������������
    //        StartCoroutine(IdleFarm());         //������������� ���� ��������������� ���������� �����
            
    //    }
    //}
    //// TODO ����� ��������� ���������� - �����

    // TODO ����� ��������������� ���������� ����� - ������
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(2); //��������� ����� ��������� ����� ������
        money++;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(money);
        StartCoroutine(IdleFarm());         //������������� ����
    }
    // TODO ����� ��������������� ���������� ����� - �����


    // TODO ����� �������� ����� - ������
    public void OnBackPresed()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    // TODO ����� �������� ����� - �����

    // Update is called once per frame
    void Update()
    {
        
    }
}
