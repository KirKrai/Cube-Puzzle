using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintUp : MonoBehaviour
{

    public Text TextHit;//����� ���������
    public GameObject TextH; //������ ������� ���� �������� � ����������
    

    void OnTriggerEnter(Collider other) 
    {
       
        TextH.SetActive(true);
        if (PlayerController.numberText == 0)
        {
            TextHit.text = "�������� ��������� ���������� �� ������� ������ WASD";
        }
        else if (PlayerController.numberText == 1)
        {
            TextHit.text = "���� ���� ������� ��� ������ � ����� �� ����� ������. ���� �� ������� ��� ������, �� ������ ����� ����������� �����";
           
        }
        else if (PlayerController.numberText == 2)
        {
            TextHit.text = "������ ���������� ��������� ����� ������ � �������� �� ���������, ������� �������������� ��� ������ ��������";
           
        }
        else if (PlayerController.numberText == 3)
        {
            TextHit.text = "�� ��������� ���� ������ �������������";
           
        }
        else if (PlayerController.numberText == 4)
        {
            TextHit.text = "������ ���������� ��������� ����� ��������� � ��������� � ����� �����";
           
        }
        else if (PlayerController.numberText == 5)
        {
            TextHit.text = "������ ������������ ���������� ��������� ����������� ������";
            
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
