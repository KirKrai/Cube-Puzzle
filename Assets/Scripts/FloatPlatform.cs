using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPlatform : MonoBehaviour
{
    public float MinX1; //начальное положение платформы на оси X
    public float MaxX2;//конечное положение платформы на оси X

    public float MinZ1; //начальное положение платформы на оси Z
    public float MaxZ2;//конечное положение платформы на оси Z

    public float speed; //скорость движения платформы
    bool moveRigth = true; //условие движения плаформы вперед или назад

    public bool move; //направление движения платформы



    


    //передвижение по оси X
    void MoveX()
    {
        //диапазон движения
        if (transform.position.x < MinX1)
            {
                moveRigth = true;
                
            }
        else if (transform.position.x > MaxX2)
            {
                moveRigth = false;
 
           
        }
        //перемещение от начального до конечного положения
        if (moveRigth)
        {
            transform.position = new Vector3(transform.position.x +speed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else if (!moveRigth)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        

    }

    //передвижение по оси Z
    IEnumerator MoveZ()
    {
        //диапазон движения
        if (transform.position.z < MinZ1)
        {
           
            yield return new WaitForSeconds(3);
            moveRigth = true;
           
        }
        else if (transform.position.z > MaxZ2)
        {
            
            yield return new WaitForSeconds(3);
            moveRigth = false;
            
        }
       
        //перемещение от начального до конечного положения
        if (moveRigth)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        }
        else if(!moveRigth)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }

    }

    void Update()
    {
       

        if (move)
        {
           MoveX();
        }
        else
        {
            StartCoroutine(MoveZ());
        }
        
    }
}
