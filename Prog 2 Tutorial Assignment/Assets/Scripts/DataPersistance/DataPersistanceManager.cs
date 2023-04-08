using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    //Static makes it singleton
    public static DataPersistanceManager manager;
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    // Encryption
    [SerializeField] private bool useEncryption;

    private FileHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;
    private void Awake()
    {
        if(manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("Found more than one Data Persistance Manager in the scene");
        }
        LoadGame();
    }
    private void Start()
    {
        this.dataHandler = new FileHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No data was found! Initializing data to default.");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
        //Debug.Log("Loaded score = " + gameData.score);
    }
    public void SaveGame()
    {
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

        //Debug.Log("Saved score = " + gameData.score);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
