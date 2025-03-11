using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

[Serializable]
public class MultiText
{
    public string ruText;
    public string enText;
    
    public MultiText(string ruText, string enText)
    {
        this.ruText = ruText;
        this.enText = enText;
    }
    
    public string GetText()
    {
        return MultiTextUI.lang == "ru" ? ruText : enText;
    }
}

public class MultiTextUI : MonoBehaviour
{
    [SerializeField] private string ruText;
    [SerializeField] private string enText;

    private TMP_Text _text;

    public static string lang = "ru";

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        if (_text != null)
        {
            _text.text = lang == "ru" ? ruText : enText;
        }
        else
        {
            GetComponent<Text>().text = lang == "ru" ? ruText : enText;
        }
    }
}