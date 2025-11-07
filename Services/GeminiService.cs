using GenerativeAI;

namespace apam.Services
{
    public class GeminiService
    {
        private string apiKey = "AIzaSyABWVRJMeKxStjVNF1AbzwKjtsnbdEz_GI";
        private GenerativeModel model;

        public GeminiService()
        {
            model = new GenerativeModel(apiKey, "gemini-2.5-flash");
        }

        public async Task<string> GenerateContentAsync(string prompt)
        {
            try
            {
                var response = await model.GenerateContentAsync(prompt);
                return response.Text;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

    }
}
