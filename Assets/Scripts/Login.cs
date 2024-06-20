using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField txtUsername;
    public InputField txt_Password;
    public Button btnLogin;
    // Start is called before the first frame update
    void Start()
    {
        btnLogin.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        string username = txtUsername.text;
        string password = txt_Password.text;
        StartCoroutine(LoginFunc(username, password));
    }

    private IEnumerator LoginFunc(string username, string password)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
