using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

    public bool isFullscreen = false; //������������� �����
    Resolution[] rsl;//������ � ������������ ������
    List<string> resolutions;//����� ������� ����� ���������� ����������
    public Dropdown Res;//������ ��� ����������

    public GameObject Background;//����� �������� ����
    public GameObject SettingMenu;//����� ���� ��������
    public GameObject LvlMenu;//����� ���� ������ ������

    //��������� ���� ���������� ������ � ���������� ��
    public void Start()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        Res.ClearOptions();
        Res.AddOptions(resolutions);
        Screen.SetResolution(rsl[rsl.Length-1].width, rsl[rsl.Length - 1].height, isFullscreen); //���������� ��������� ����������� ���������� ������ �� ���������
    }
    //��������� ����������
    public void ChangeResolution()
    {
        Screen.SetResolution(rsl[Res.value].width, rsl[Res.value].height, isFullscreen);
    }

    //��������� ��� ���������� �������������� ������
    public void ChangeFullscreenMode()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        

    }



    //������� �������� ���� � ����� ���� ���������
    public void ShowMenuSetting()
    {
        Background.SetActive(false);
        SettingMenu.SetActive(true);

    }
    //������� �������� ���� � ����� ���� ������ ������
    public void ShowMenuLvl()
    {
        Background.SetActive(false);
        LvlMenu.SetActive(true);
    }
    //������� ���� ���� � ����� �������� ����
    public void ShowMenuMain()
    {
        LvlMenu.SetActive(false);
        SettingMenu.SetActive(false);
        Background.SetActive(true);
    }


    //������ ����� ����
    public void Play()
    {
        SceneManager.LoadScene(1);//�������� ������ �����(��������)
    }

    //������ ������� 1
    public void PlayLvl1()
    {
        SceneManager.LoadScene(2);//�������� ������ �����(������� 1)
    }


    //������ ����� �� ����
    public void Exit() 
    {
        Application.Quit();//�������� ����������
    }
    
}

