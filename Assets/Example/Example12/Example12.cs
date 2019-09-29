using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example12 : MonoBehaviour
{
    struct LoadDataModel
    {
        public bool IsSuccess { get; set; }
        public string Data { get; set; }

        public LoadDataModel(bool isSuccess, string data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }
    }

    private void Start()
    {
        var loadData = LoadData();
        if (loadData.IsSuccess)
        {
            Debug.Log(loadData.Data);
        }
    }

    /// <summary>
    /// 데이터를 로드 한다.
    /// </summary>
    /// <returns> </returns>
    private LoadDataModel LoadData()
    {
        try
        {
            // 뭔가를 로드 하는 처리
            var data = "로드 된 데이터";
            return new LoadDataModel(true, data);
        }
        catch (Exception e)
        {
            return new LoadDataModel(false, null);
        }
    }
}
