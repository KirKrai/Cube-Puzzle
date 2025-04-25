using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//�� ����� ������, ���� �� ������� �� ����� ���������� Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameObject target;//������ ������
    public GameObject targetPre;//������ ������

    public static int coin = 0; //���������� �������, ��������� �������
    public GameObject[] coinMassive;//������, ��� ������� ��� �������, ������� �������� �� ������
    public static int coinStill;//���������� ����� ���������� �� ������
    public Text coinText;//����� ������� ���������� ���������� �����


    public float Speed;//������������ �������� ������
    public float StartSpeed;//��������� �������� ������

    private Rigidbody _rb;

    //��������� ������ ��� ������ ��������
    public Material materialBig;
    public Material materialSmall;
    public Material materialNormal;


    public static int numberText;//������� ���������� ���������

    void Start()
    {
        Time.timeScale = 1f;
        coin = 0;
        _rb = GetComponent<Rigidbody>();
        coinMassive = GameObject.FindGameObjectsWithTag("Coin");
        coinStill = coinMassive.Length;
        coinText.text = "��������� ������:" + coin.ToString() + "\n" + "����� ��������:" + coinStill.ToString();
        numberText = 0;
        

    }

    //��� �������� � �������
    void FixedUpdate()
    {
        MovementLogic();

    }
    //�������� ��������� � �����-�� ���������
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    //����� ��������� ��������
    void OnTriggerEnter(Collider other)
    {
        //������������ �� ���������� ���������
        if (other.gameObject.tag == "FloatingPlatform")
        {
            targetPre.transform.parent = other.gameObject.transform;
        }


        //�������������� � ��������
        if (other.gameObject.tag == "FruiteBig")
        {
            other.gameObject.SetActive(false);
            target.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            target.GetComponent<MeshRenderer>().material = materialBig;

        }
        if (other.gameObject.tag == "FruiteNormal")
        {
            other.gameObject.SetActive(false);
            target.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            target.GetComponent<MeshRenderer>().material = materialNormal;


        }
        if (other.gameObject.tag == "FruiteSmall")
        {
            other.gameObject.SetActive(false);
            target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            target.GetComponent<MeshRenderer>().material = materialSmall;
        }

       

        //������� �������
        if (other.gameObject.tag == "Coin")
        {
            coin++;
            coinStill--;
            other.gameObject.SetActive(false);
            coinText.text = "��������� ������:" + coin.ToString() + "\n" + "����� ��������:" + coinStill.ToString();

        }

        //������� ����������� ���������
        if (other.gameObject.tag == "HintTextBox")
        {
            numberText++;

        }



    }




    private void OnTriggerExit(Collider other)
    {
        //��� ������ � ���������� ���������
        if (other.gameObject.tag == "FloatingPlatform")
        {
            targetPre.transform.parent = null;
        }

    }



     void Update()
    {
        
        //��� ������������ �������� �������
        if (_rb.velocity.magnitude >= Speed)
        {
            _rb.velocity = _rb.velocity.normalized * Speed;
        }
        if ((_rb.velocity.magnitude <= StartSpeed) && (Input.GetAxis("Horizontal") != 0))
        {
            _rb.velocity = _rb.velocity.normalized * StartSpeed;
        }
        if ((_rb.velocity.magnitude <= StartSpeed) && (Input.GetAxis("Vertical") != 0))
        {
            _rb.velocity = _rb.velocity.normalized * StartSpeed;
        }

    }
    }
