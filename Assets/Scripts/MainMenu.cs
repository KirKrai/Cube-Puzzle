using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

    public bool isFullscreen = false; //Полноэкранный режим
    Resolution[] rsl;//массив с разрешениями экрана
    List<string> resolutions;//текст который будет показывать разрешения
    public Dropdown Res;//кнопка для разрешений

    public GameObject Background;//экран главного меню
    public GameObject SettingMenu;//экран меню настроек
    public GameObject LvlMenu;//экран меню выбора уровня

    //получение всех разрешений экрана и сохранение их
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
        Screen.SetResolution(rsl[rsl.Length-1].width, rsl[rsl.Length - 1].height, isFullscreen); //изначально выставить максимально разрешение экрана из доступных
    }
    //Изменение разрешения
    public void ChangeResolution()
    {
        Screen.SetResolution(rsl[Res.value].width, rsl[Res.value].height, isFullscreen);
    }

    //Включение или отключение полноэкранного режима
    public void ChangeFullscreenMode()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        

    }



    //Скрытие главного меню и показ меню настройки
    public void ShowMenuSetting()
    {
        Background.SetActive(false);
        SettingMenu.SetActive(true);

    }
    //Скрытие главного меню и показ меню выбора уровня
    public void ShowMenuLvl()
    {
        Background.SetActive(false);
        LvlMenu.SetActive(true);
    }
    //Скрытие всех меню и показ главного меню
    public void ShowMenuMain()
    {
        LvlMenu.SetActive(false);
        SettingMenu.SetActive(false);
        Background.SetActive(true);
    }


    //кнопка Новая игра
    public void Play()
    {
        SceneManager.LoadScene(1);//загрузка первой сцены(обучения)
    }

    //кнопка уровень 1
    public void PlayLvl1()
    {
        SceneManager.LoadScene(2);//загрузка второй сцены(уровень 1)
    }


    //кнопка Выход из игры
    public void Exit() 
    {
        Application.Quit();//закрытие приложения
    }
    
}

