using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPlatform : MonoBehaviour
{
    public float MinX1; //��������� ��������� ��������� �� ��� X
    public float MaxX2;//�������� ��������� ��������� �� ��� X

    public float MinZ1; //��������� ��������� ��������� �� ��� Z
    public float MaxZ2;//�������� ��������� ��������� �� ��� Z

    public float speed; //�������� �������� ���������
    bool moveRigth = true; //������� �������� �������� ������ ��� �����

    public bool move; //����������� �������� ���������



    


    //������������ �� ��� X
    void MoveX()
    {
        //�������� ��������
        if (transform.position.x < MinX1)
            {
                moveRigth = true;
                
            }
        else if (transform.position.x > MaxX2)
            {
                moveRigth = false;
 
           
        }
        //����������� �� ���������� �� ��������� ���������
        if (moveRigth)
        {
            transform.position = new Vector3(transform.position.x +speed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else if (!moveRigth)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        

    }

    //������������ �� ��� Z
    IEnumerator MoveZ()
    {
        //�������� ��������
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
       
        //����������� �� ���������� �� ��������� ���������
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
