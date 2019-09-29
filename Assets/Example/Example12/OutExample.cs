using System;
using UnityEngine;

public class OutExample : MonoBehaviour
{
    private void Start()
    {
        if (LoadData(out var loadData))
        {
            Debug.Log(loadData);
        }
    }

    /// <summary>
    /// 데이터를 로드 한다.
    /// </summary>
    /// <param name="data">로드 성공시 값</param>
    /// <returns>로드 성공 여부</returns>
    private bool LoadData(out string data)
    {
        try
        {
            // 뭔가 로드 처리
            data = "로드 된 데이터";
            // 성공하면 true 반환
            return true;
        }
        catch (Exception e)
        {
            data = null;
            // 예외가 나오면 false 반환
            return false;
        }
    }
}
