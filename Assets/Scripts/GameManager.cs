using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Text textCalcium;
    [SerializeField]
    private GameObject panelPurchase;

    private string filePath = "";

    private string jsonString = "";

    public void Start()
    {
        player = new Player();
        filePath = string.Concat(Application.persistentDataPath, "/", "Save154.txt");
        OnClickLoad();
        Debug.Log("filePath : " + filePath);
    }

    public void UpdateCalcium()
    {
        if (textCalcium == null) return;
        textCalcium.text = string.Format("{0} cl", player.calcium);
    }

    public void OnClick()
    {
        player.calcium += player.calciumPerClick;
        UpdateCalcium();
    }

    public void OnClickSave()
    {
        jsonString = JsonUtility.ToJson(player);
        Debug.Log("JSON : " + jsonString);
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);

        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        fs.Write(data, 0, data.Length);
        fs.Close();
    }

    public void OnClickLoad() 
    {
        FileStream fs = new FileStream(filePath, FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);
        fs.Close();

        jsonString = Encoding.UTF8.GetString(data);
        player = JsonUtility.FromJson<Player>(jsonString);

        UpdateCalcium();
    }

    private void OnApplicationQuit()
    {
        OnClickSave();
    }

    public void ActivePurchasePanel() 
    {
        panelPurchase.SetActive(!panelPurchase.activeInHierarchy);
    }
}
