using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using UnityEngine;
using System.Net.Http.Headers;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using System.Threading.Tasks;
using TMPro;


using static CohereChat;


[System.Serializable]
public class Response
{
    public bool is_finished;
    public string event_type;
    public string conversation_id;
    public string generation_id;
    public string text;
}
public class CohereChat : MonoBehaviour
{

    public int maxTurns;
    public int maxTokens;
    public string conversationId;
    [TextArea]
    public string initPrompt;

    public TextMeshProUGUI replyText;
    public TMP_InputField playerInput;



    // Start is called before the first frame update

    [ContextMenu("Call Req")]
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           
    }

    async Task SendMessage()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api.cohere.ai/v1/chat"),
            Headers =
    {
        { "accept", "application/json" },
        { "authorization", "Bearer 5GwHHy04UlGoyNrY7glMvlI9FyPVkTfixbutPws6" },
    },
            Content = new StringContent("{\"message\":\"" + playerInput.text.ToString() + "\",\"stream\":true,\"preamble_override\":\"string\",\"conversation_id\":\"" + conversationId + "\",\"prompt_truncation\":\"auto\",\"search_queries_only\":false,\"citation_quality\":\"accurate\",\"temperature\":0.7,\"max_tokens\":70,\"top_p\":0.8}")
            {
                Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
            }
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        

        var body = await response.Content.ReadAsStringAsync();
        string contactedReply = "";
        string[] jsonLines = body.Split('\n');
        foreach (string line in jsonLines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            Response resp = JsonUtility.FromJson<Response>(line);

            if (resp.is_finished == false && resp.event_type == "text-generation")
            {
                       contactedReply += resp.text;
                       SetReplyText(contactedReply);
            }
            
        }
       
    }

  
    public void SendMessageEvent()
    {
        SendMessage();
        //playerInput.text = string.Empty;
    }

    public void SetReplyText(string rep)
    {
        replyText.text = rep;
    }
}



