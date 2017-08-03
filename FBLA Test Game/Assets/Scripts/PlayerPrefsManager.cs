using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string TOTAL_MONEY_KEY = "total_money";
    const string CURRENT_UPGRADE_PRICE_KEY = "current_upgrade_price";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetTotalMoney(int money)
    {
        PlayerPrefs.SetInt(TOTAL_MONEY_KEY, money);
    }

    public static int GetTotalMoney()
    {
        return PlayerPrefs.GetInt(TOTAL_MONEY_KEY);
    }

    public static void SetUpgradePrices(int[] upgradePrices)
    {
        PlayerPrefsX.SetIntArray(CURRENT_UPGRADE_PRICE_KEY, upgradePrices);
    }

    public static int[] GetUpgradePrices()
    {
        return PlayerPrefsX.GetIntArray(CURRENT_UPGRADE_PRICE_KEY);
    }
    
}
