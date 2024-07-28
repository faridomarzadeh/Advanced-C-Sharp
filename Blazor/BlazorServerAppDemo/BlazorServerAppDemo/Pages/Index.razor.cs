using BlazorServerAppDemo.Models;

namespace BlazorServerAppDemo.Pages
{
    public partial class Index
    {
        private List<Contact> contacts;
        private Dictionary<string, object> Attributes = new Dictionary<string, object>
    {
        {"disabled","disabled" },
        {"placeholder","First Name"},
        {"type","text"}
    };

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(5000);
            contacts = new List<Contact>()
        {
            new Contact()
            {
                FirstName = "John",
                LastName = "Thomas",
                Email = "john@gmail.com"
            },
            new Contact()
            {
                FirstName = "Tim",
                LastName = "Johnson",
                Email = "tjohnson@yahoo.com"
            },
            new Contact()
            {
                FirstName = "Peter",
                LastName = "Bob",
                Email = "peter@gmail.com"
            }
        };
        }
    }
}
