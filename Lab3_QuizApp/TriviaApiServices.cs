using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TriviaApiServices
{
    public async Task<List<QuestionItem>> GetQuestionsAsync(int amount = 5)
    {
        string url = $"https://opentdb.com/api.php?amount={amount}&type=multiple";

        using HttpClient client = new HttpClient();
        var response = await client.GetFromJsonAsync<TriviaResponse>(url);

        return response?.results ?? new List<QuestionItem>();
    }
}


public class TriviaResponse
{
    public int response_code { get; set; }
    public List<QuestionItem> results { get; set; }
}

public class QuestionItem
{
    public string category { get; set; }
    public string question { get; set; }
    public string correct_answer { get; set; }
    public List<string> incorrect_answers { get; set; }
}