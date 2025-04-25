using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//не будет ошибки, если на объетке не будет компонента Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameObject target;//Объект Игрока
    public GameObject targetPre;//Префаб Игрока

    public static int coin = 0; //колиечство монеток, собранных игроком
    public GameObject[] coinMassive;//массив, где соберем все монетки, которые остались на уровне
    public static int coinStill;//количество монет оставшихся на уровне
    public Text coinText;//текст который показывает количество монет


    public float Speed;//Максимальная скорость игрока
    public float StartSpeed;//начальная скорость игрока

    private Rigidbody _rb;

    //материалы игрока при разных размерах
    public Material materialBig;
    public Material materialSmall;
    public Material materialNormal;


    public static int numberText;//счетчик пройденных подсказок

    void Start()
    {
        Time.timeScale = 1f;
        coin = 0;
        _rb = GetComponent<Rigidbody>();
        coinMassive = GameObject.FindGameObjectsWithTag("Coin");
        coinStill = coinMassive.Length;
        coinText.text = "Собранные монеты:" + coin.ToString() + "\n" + "Монет осталось:" + coinStill.ToString();
        numberText = 0;
        

    }

    //все действия с физикой
    void FixedUpdate()
    {
        MovementLogic();

    }
    //движение персонажа с какой-то скоростью
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    //когда подбирает предметы
    void OnTriggerEnter(Collider other)
    {
        //передвижение на движущийся платформе
        if (other.gameObject.tag == "FloatingPlatform")
        {
            targetPre.transform.parent = other.gameObject.transform;
        }


        //взаимодействие с фруктами
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

       

        //счетчик монеток
        if (other.gameObject.tag == "Coin")
        {
            coin++;
            coinStill--;
            other.gameObject.SetActive(false);
            coinText.text = "Собранные монеты:" + coin.ToString() + "\n" + "Монет осталось:" + coinStill.ToString();

        }

        //порядок показывания подсказок
        if (other.gameObject.tag == "HintTextBox")
        {
            numberText++;

        }



    }




    private void OnTriggerExit(Collider other)
    {
        //при выходе с дивжущийся платформы
        if (other.gameObject.tag == "FloatingPlatform")
        {
            targetPre.transform.parent = null;
        }

    }



     void Update()
    {
        
        //для нормализации скорости объекта
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
