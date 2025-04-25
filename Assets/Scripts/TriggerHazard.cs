using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TriggerHazard : MonoBehaviour
{
    //���������� ������
    public void RestartLvl()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    //��� ��������� � ������ �������� ��������� � ������ (����������� ����������) � ����� 2 ������� ��������������� �������
    void OnTriggerEnter(Collider other)
    {

        other.gameObject.SetActive(false);

        Invoke("RestartLvl", 2);

    }
}
