using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{

   

    public GameObject door;//������ �����, ������� ����� ���������
    public GameObject doorText;//����� ������� ������� �� �������� �����



    //���������� ������ �����
    void DoorDisEnable()
    {
        doorText.SetActive(false);
    }

    void Start()
    {
        DoorDisEnable();//��������� �����, ���� �� �������
    }
   

    void Update()
    {
     //�������� ����� ����� ����� ������ ��� ������� � �������� ���� �� ���� ����� 5 ������
     if(PlayerController.coinStill==0)
        {
            door.SetActive(false);
            doorText.SetActive(true);
            Invoke("DoorDisEnable", 5f);

        }   
        
    }
}
