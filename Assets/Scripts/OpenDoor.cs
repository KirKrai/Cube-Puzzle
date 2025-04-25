using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{

   

    public GameObject door;//объект дверь, которую будем открывать
    public GameObject doorText;//текст который сообщит об открытие двери



    //отключение текста двери
    void DoorDisEnable()
    {
        doorText.SetActive(false);
    }

    void Start()
    {
        DoorDisEnable();//отключаем текст, если он активен
    }
   

    void Update()
    {
     //открытие двери когда игрок собрал все монетки и закрытие окна об этом через 5 секунд
     if(PlayerController.coinStill==0)
        {
            door.SetActive(false);
            doorText.SetActive(true);
            Invoke("DoorDisEnable", 5f);

        }   
        
    }
}
