using lab10_phonebook_crud.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace lab10_phonebook_crud.Controllers
{
    public class PhonebookController : Controller
    {
        private string connectionString = "server=localhost;user=late;password=Sqlp@ssw0rd;port=3306;database=sem6_dotnet";
        public IActionResult Index()
        {
            List<PhonebookModel> phoneBookList = new List<PhonebookModel>();

            MySqlConnection conn = new MySqlConnection(connectionString);
            var query = "SELECT * FROM phonebook_lab10";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                PhonebookModel phoneData = new PhonebookModel();
                phoneData.Id = Convert.ToInt32(rdr["id"]);
                phoneData.Name = rdr["name"].ToString();
                phoneData.Number = rdr["number"].ToString();
                phoneData.Email = rdr["email"].ToString();
                phoneData.Address = rdr["address"].ToString();
                phoneBookList.Add(phoneData);
            }
            conn.Close();
            return View(phoneBookList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhonebookModel phonebookRecord)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            var query = "INSERT INTO phonebook_lab10 (name, number, email, address) VALUES (@name, @number, @email, @address)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", phonebookRecord.Name);
            cmd.Parameters.AddWithValue("@number", phonebookRecord.Number);
            cmd.Parameters.AddWithValue("@email", phonebookRecord.Email);
            cmd.Parameters.AddWithValue("@address", phonebookRecord.Address);

            conn.Open();
            if (ModelState.IsValid)
            {
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            MySqlConnection conn = new MySqlConnection(connectionString);

            var query = "SELECT * FROM phonebook_lab10 WHERE ID=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            PhonebookModel phoneData = new PhonebookModel();
            while (rdr.Read())
            {
                phoneData.Id = Convert.ToInt32(rdr["id"]);
                phoneData.Name = rdr["name"].ToString();
                phoneData.Number = rdr["number"].ToString();
                phoneData.Email = rdr["email"].ToString();
                phoneData.Address = rdr["address"].ToString();
            }
            conn.Close();

            if (phoneData == null)
            {
                return NotFound();
            }

            return View(phoneData);
        }

        [HttpPost]
        public IActionResult Edit(PhonebookModel updatedData)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            var query = "UPDATE phonebook_lab10 SET name=@name, number=@number, email=@email, address=@address WHERE id=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", updatedData.Id);
            cmd.Parameters.AddWithValue("@name", updatedData.Name);
            cmd.Parameters.AddWithValue("@number", updatedData.Number);
            cmd.Parameters.AddWithValue("@email", updatedData.Email);
            cmd.Parameters.AddWithValue("@address", updatedData.Address);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            var query = "DELETE FROM phonebook_lab10 WHERE id=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            return RedirectToAction("Index");
        }
    }
}
