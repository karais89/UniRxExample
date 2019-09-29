using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TupleExample : MonoBehaviour
{
    private void Start()
    {
        var result = LoadData();
        if (result.Item1)
        {
            var loadData = result.Item2;
            Debug.Log(loadData);
        }
        
        // 위와 같은 형태, 명시적으로 변수명 선언
        var (isSuccesses, loadData2) = LoadData();
        if (isSuccesses)
        {
            Debug.Log(loadData2);
        }
    }

    private (bool isSuccessed, string data) LoadData()
    {
        try 
        { 
            // 여기서 로드 처리
            return (true, "로드 된 데이터");
        } 
        catch 
        { 
            return (false, null);
        }
    }
}