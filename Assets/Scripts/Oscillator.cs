using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    //movementFactor : 움직였다가 제자리로 돌아가게 하기 위해 0,1로 범위 설정

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }

        //시간에 따라 계속해서 증가
        float cycles = Time.time / period;

        //상수
        const float tau = Mathf.PI * 2;

        //-1,1
        float rawSinWave = Mathf.Sin(cycles * tau);

        //0,1
        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset; 
    }
}
