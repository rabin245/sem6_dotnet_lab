using lab8_display_db.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace lab8_display_db.Controllers
{
    public class CollegeController : Controller
    {
        private string connStr = "server=localhost;user=late;password=Sqlp@ssw0rd;port=3306;database=sem6_dotnet";
        public IActionResult Index()
        {
            List<CollegeModel> collegeList = new List<CollegeModel>();

            MySqlConnection conn = new MySqlConnection(connStr);
            var query = "SELECT * FROM college_lab8";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                CollegeModel collegeData = new CollegeModel();
                collegeData.Id = Convert.ToInt32(rdr["id"]);
                collegeData.Name = rdr["full_name"].ToString();
                collegeData.Number = rdr["contact_no"].ToString();
                collegeData.Email = rdr["email"].ToString();
                collegeList.Add(collegeData);
            }
            conn.Close();
            return View(collegeList);
        }
    }
}
