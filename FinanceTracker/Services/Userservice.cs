
using FinanceTracker.Models;

using System.Text.Json;


namespace FinanceTracker.Services

{

    public class UserService

    {

        private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


        private static readonly string FolderPath = Path.Combine(DesktopPath, "Test");


        private static readonly string FilePath = Path.Combine(FolderPath, "users.json");


        // Load AppData from JSON

        public AppData LoadData()

        {
            if (!File.Exists(FilePath))

                return new AppData();


            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<AppData>(json) ?? new AppData();

        }


        // Save AppData to JSON

        public void SaveData(AppData data)

        {

            if (!Directory.Exists(FolderPath))

            {


                Directory.CreateDirectory(FolderPath);


            }



            if (!File.Exists(FilePath))

            {


                File.WriteAllText(FilePath, "[]");


            }

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FilePath, json);

        }


        // Calculate main balance for a user

        public decimal CalculateBalance(int userId, AppData data)

        {

            var userTransactions = data.Transactionpage.Where(t => t.UserId == userId).ToList();

            decimal totalCredit = userTransactions.Sum(t => t.Credit);

            decimal totalDebit = userTransactions.Sum(t => t.Debit);

            return totalCredit - totalDebit;

        }


        // Calculate debt clearing and remaining amounts

        public (decimal Cleared, decimal Remaining) CalculateDebt(int userId, AppData data)

        {

            var userDebts = data.Debts.Where(d => d.UserId == userId).ToList();

            decimal totalDebt = userDebts.Sum(d => d.Amount);

            decimal totalPaid = userDebts.Sum(d => d.PaidAmount);

            return (totalPaid, totalDebt - totalPaid);

        }

    }

}
