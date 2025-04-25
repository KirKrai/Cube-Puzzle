using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform PlayerTarget;//игровой объект за которым будет следовать камера
    public float smooth;//скорось передвижения камеры
    public Vector3 offset;//координаты камеры относительно объекта

  
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTarget.position + offset, Time.deltaTime*smooth);

    }
}
