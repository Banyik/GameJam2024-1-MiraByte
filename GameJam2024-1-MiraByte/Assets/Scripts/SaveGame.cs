using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using Player;

public class SaveGame : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        //LoadXml();
    }
    private void SaveXml() 
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlElement root = xmlDoc.CreateElement("Save");

        XmlElement playerPosX = xmlDoc.CreateElement("PlayerPosX");
        playerPosX.InnerText = player.transform.position.x.ToString();
        root.AppendChild(playerPosX);

        XmlElement playerPosY = xmlDoc.CreateElement("PlayerPosY");
        playerPosY.InnerText = player.transform.position.y.ToString();
        root.AppendChild(playerPosY);

        XmlElement prisonerOrGuard = xmlDoc.CreateElement("PrisonerOrGuard");
        prisonerOrGuard.InnerText = player.GetComponent<PlayerBehaviour>().playerType.ToString();
        root.AppendChild(prisonerOrGuard);

        xmlDoc.AppendChild(root);
        xmlDoc.Save(Application.dataPath + "/Data.text");
        if (File.Exists(Application.dataPath + "/Data.text"))
        {
            Debug.Log("Saved");
        }
    }
    private void LoadXml() 
    {
        if (File.Exists(Application.dataPath + "/Data.text"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.dataPath + "/Data.text");

            XmlNodeList playerPosXXml = xmlDoc.GetElementsByTagName("PlayerPosX");
            float playerPosX = float.Parse(playerPosXXml[0].InnerText);
            

            XmlNodeList playerPosYXml = xmlDoc.GetElementsByTagName("PlayerPosY");
            float playerPosY = float.Parse(playerPosYXml[0].InnerText);

            XmlNodeList prisonerOrGuard = xmlDoc.GetElementsByTagName("PrisonerOrGuard");
            PlayerType playerType;
            if (prisonerOrGuard[0].InnerText == "Prisoner")
            {
                playerType = PlayerType.Prisoner;
            }
            else
            {
                playerType = PlayerType.Prisoner;
            }
            
            player.transform.position = new Vector2(playerPosX,playerPosY);
            player.GetComponent<PlayerBehaviour>().playerType = playerType;

        }
        else 
        {
            Debug.Log("file doesn't exist");
        }
    }
}
