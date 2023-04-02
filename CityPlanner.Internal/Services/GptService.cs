using System.Text.Json;

namespace CityPlanner.Internal.Services
{
    public class GptService
    {
        public async Task GetResultsAnalysis(ResultsDTO results, UserDTO userData)
        {
            Console.WriteLine("here1");
            var api = new OpenAI_API.OpenAIAPI("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");

            Console.WriteLine("here2.");
            var chat = api.Chat.CreateConversation();

            Console.WriteLine("here3.");
            chat.AppendSystemMessage("You are a model, which is used to put into words judgement on a location for someone's potential new home. You should try to motivate the user to move to this location. " +
                "You will receive information about a specific location, like what amenities are within a 15-minute walk, whether the place has bars for an active life etc. " +
                "The data will be presented in two JSONs, first one describing the information about the location and the second one data about the user. " +
                "Enum values about ChildAspiration are these: NotPlanned = 0, WithinFiveYears = 1, ConcernNow = 3. " +
                "The score is provided out of a 100.");

            Console.WriteLine("here4.");

            /*var options = new JsonSerializerOptions()
            {
                MaxDepth = 2
            };*/
            //var resultsJson = JsonSerializer.Serialize(results, options);
           // chat.AppendUserInput("Eval results of the location: " + resultsJson);
            //chat.AppendUserInput("User data: " + JsonSerializer.Serialize(userData));

            Console.WriteLine("Going to wait for response.");
            var result = await chat.GetResponseFromChatbot();
            Console.WriteLine(result);
        }
    }
}
