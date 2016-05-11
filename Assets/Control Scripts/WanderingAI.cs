/*
 * Сценарий для движения ботов
 */
using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;          //Значение скорости для Enemy
    public float obstacleRange = 1.0f;  //Значение расстояния, с которого начинается реакция на препятствие
    private bool _alive;                //Логическая переменная для слежения за состоянием персонажа
	// Use this for initialization
	void Start () {
        _alive = true;  //Инициализация этой переменной
	}
	
	// Update is called once per frame
	void Update () {
        if (_alive) //Движение только живого бота
        {
            transform.Translate(0, 0, speed * Time.deltaTime);      //Движемся вперёд в каждом кадре
            Ray ray = new Ray(transform.position, transform.forward);//Луч в том же направлении что и бот
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))            //Бросаем луч с описанной вокруг него окружностью 
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}
    public void SetAlive(bool alive)    //Для внешнего кода
    {
        _alive = alive;
    }
}
