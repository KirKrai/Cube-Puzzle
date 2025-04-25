using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform PlayerTarget;//������� ������ �� ������� ����� ��������� ������
    public float smooth;//������� ������������ ������
    public Vector3 offset;//���������� ������ ������������ �������

  
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTarget.position + offset, Time.deltaTime*smooth);

    }
}
