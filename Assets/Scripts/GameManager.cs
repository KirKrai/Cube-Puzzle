using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    public Text TextE;//сообщение о конце уровня
    public GameObject TextEnd; //объект который будем скрывать и показывать
    public void ExitMenu()

    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider other)
    {
        isGameOver=true;
    }
    void Start()
    {
        TextEnd.SetActive(false);   
    }
    void OnGUI()
    {

        if (isGameOver)
        {
            TextEnd.SetActive(true);
            TextE.text = "Конец игры! \n Выход в главное меню через несколько секунд";
            Invoke("ExitMenu", 5f);
        }

    }

}
