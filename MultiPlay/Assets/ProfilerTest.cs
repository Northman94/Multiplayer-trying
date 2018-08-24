using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class ProfilerTest : MonoBehaviour 
{
    private Transform _transform;


    private void Avake()
    {
        _transform = GetComponent<Transform>(); // Кэширование дает прирост к производительности
    }


    private void Update()
    {
        // Самый непроизводительный
        Profiler.BeginSample("GetComponent<Transform>( ) Sample"); // Слово Sample чтоб мы идентифицировали в Profiler-e
        for (int i = 0; i < 10000; i++)
        {
            GetComponent<Transform>().position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        }
        Profiler.EndSample();


        // Средне производительный в сравнении
        Profiler.BeginSample("transform Sample"); // Слово Sample чтоб мы идентифицировали в Profiler-e
        for (int i = 0; i < 10000; i++)
        {
            transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        }
        Profiler.EndSample();


        // Самый производительный
        Profiler.BeginSample("_transform Sample"); // Слово Sample чтоб мы идентифицировали в Profiler-e
        for (int i = 0; i < 10000; i++)
        {
            _transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        }
        Profiler.EndSample();
    }
}
