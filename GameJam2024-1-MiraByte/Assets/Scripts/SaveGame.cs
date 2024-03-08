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
        //SaveXml();
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

        XmlElement prisonerOrGuard = xmlDoc.CreateElement("prisonerOrGuard");
        prisonerOrGuard.InnerText = player.GetComponent<PlayerBehaviour>().playerType.ToString();
        root.AppendChild(prisonerOrGuard);

        xmlDoc.AppendChild(root);
        xmlDoc.Save(Application.dataPath + "/Data.text");
        if (File.Exists(Application.dataPath + "Data.text"))
        {
            Debug.Log("Saved");
        }
    }
}
