using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[BepInPlugin("F5Hat", "Gives you F5's hat :3", "1.0.0")]
public class BeegHatLoader : BaseUnityPlugin
{
    private GameObject beegHat;
    private float scaleFactor = 37.5f;
    private const string beegHatPath = "World/Areas/IronFactory/Lod0/F5/RobotArmature/Body/Torso/Chest/Neck/Hhead/Corrupt/BeegHat";

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "BirdCage")
        {
            InstantiateBeegHat();
        }
    }

    void InstantiateBeegHat()
    {
        beegHat = GameObject.Find(beegHatPath);
        if (beegHat != null)
        {
            GameObject newHat = Instantiate(beegHat);
            newHat.name = "F5Hat";

            Transform daSkirt = newHat.transform.Find("SM_Prop_Medical_Scanner_01 (1)/DA_Skirt (1)");
            if (daSkirt != null)
            {
                daSkirt.gameObject.SetActive(false);
            }

            Transform senSpine1 = GameObject.Find("S-105.1/ROOT/Hips/Spine/Spine1").transform;
            if (senSpine1 != null)
            {
                newHat.transform.SetParent(senSpine1, false);
                UpdateHatTransform(newHat);
            }
        }
    }

    void UpdateHatTransform(GameObject hat)
    {
        hat.transform.localPosition = new Vector3(0f, 0.5567f, -0.0272f);
        hat.transform.localRotation = Quaternion.Euler(270f, 328.634f, 0f);
        hat.transform.localScale = new Vector3(scaleFactor, scaleFactor, 63.4113f);
    }
}
