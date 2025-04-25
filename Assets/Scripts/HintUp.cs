using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintUp : MonoBehaviour
{

    public Text TextHit;//текст подсказки
    public GameObject TextH; //объект который буем скрывать и показывать
    

    void OnTriggerEnter(Collider other) 
    {
       
        TextH.SetActive(true);
        if (PlayerController.numberText == 0)
        {
            TextHit.text = "Движение персонажа происходит на нажатие клавиш WASD";
        }
        else if (PlayerController.numberText == 1)
        {
            TextHit.text = "Цель игры собрать все монеты и дойти до конца уровня. Если не собрали все монеты, то проход будет преграждать дверь";
           
        }
        else if (PlayerController.numberText == 2)
        {
            TextHit.text = "Фрукты увеличения позволяют стать больше и попадать на платформы, которые труднодоступны для других размеров";
           
        }
        else if (PlayerController.numberText == 3)
        {
            TextHit.text = "До некоторых стен нельзя дотрагиваться";
           
        }
        else if (PlayerController.numberText == 4)
        {
            TextHit.text = "Фрукты уменьшения позволяют стать маленьким и проходить в узкие места";
           
        }
        else if (PlayerController.numberText == 5)
        {
            TextHit.text = "Фрукты нормализации возвращают персонажу стандартный размер";
            
        }           

    }
    void OnTriggerExit(Collider other) 
    {
        TextH.SetActive(false);
    }

    void Start()
    {
        TextH.SetActive(false);
    }
}
