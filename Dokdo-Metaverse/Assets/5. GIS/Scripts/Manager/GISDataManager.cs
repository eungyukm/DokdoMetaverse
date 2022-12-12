using System.IO;
using UnityEngine;

public class GISDataManager
{
    private static GISDataManager Instance;


    public static GISDataManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new GISDataManager();
            return Instance;
        }
        
        return Instance;
    }
    
    private const string localDataFolderName = "Datas";
    private const string mapDataFileName = "MapData";
    private const string Extension = ".json";
    
    private string localDataFolderPath = null;
    private string appSettingDataJsonFilePath = null;

    public GISDataManager()
    {
        localDataFolderPath = Path.Combine(Application.persistentDataPath, localDataFolderName);
    }
    
    // 데이터 저장
    public void SaveLocalData(string jsonName, string jsonData)
    {
        string path = Path.Combine(localDataFolderPath,jsonName + Extension);
        // 로컬에 파일이 있는지 체크
        if (File.Exists(path))
        {
            Debug.Log("oldUser Folder path : " + localDataFolderPath);
            File.WriteAllText(path, jsonData);
        }
        else
        {
            // 디렉토리가 없는 경우 디렉토리 생성
            if (!Directory.Exists(localDataFolderPath))
            {
                Directory.CreateDirectory(localDataFolderPath);
            }
            File.WriteAllText(path, jsonData);
        }
    }
    
    // 데이터 읽기
    public string LoadData(string jsonName)
    {
        string path = Path.Combine(localDataFolderPath,jsonName + Extension);
        Debug.Log("path : " + path);
        
        // 로컬에 파일이 있는지 체크
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return json;
        }

        return null;
    }
}
