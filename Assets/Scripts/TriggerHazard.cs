using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TriggerHazard : MonoBehaviour
{
    //перезапуск уровня
    public void RestartLvl()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    //При вхождение в объект персонаж пропадает с экрана (становиться неактивным) и через 2 секунды перезапускается уровень
    void OnTriggerEnter(Collider other)
    {

        other.gameObject.SetActive(false);

        Invoke("RestartLvl", 2);

    }
}
