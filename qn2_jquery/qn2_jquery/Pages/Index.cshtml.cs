using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace qn2_jquery.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(string name, string password)
        {
            var conStr = "server=localhost;user=late;password=Sqlp@ssw0rd;database=sem6_dotnet;port=3306";
            MySqlConnection con = new MySqlConnection(conStr);
            var sql = "select count(*) from qn2_usertable where name=@name and password=@password";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    return RedirectToPage("Privacy");
                }
                ViewData["unsucess"] = "Login Failed.Please check your username and password";
                return Page();

            }
            catch (Exception ex) 
            {
                return Page();
            }
        }
    }
}