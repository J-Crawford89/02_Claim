using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim
{
    class ProgramUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaims();
            RunMenu();
        }
        private void SeedClaims()
        {
            Claims claimOne = new Claims(1, Claims.Category.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claims claimTwo = new Claims(2, Claims.Category.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 26), new DateTime(2018, 4, 28));
            Claims claimThree = new Claims(3, Claims.Category.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));
            _claimRepo.AddToDirectory(claimOne);
            _claimRepo.AddToDirectory(claimTwo);
            _claimRepo.AddToDirectory(claimThree);
        }
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Please select a number\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.Clear();
                        _claimRepo.ShowAllClaims();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        _claimRepo.DealWithClaim();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private bool EnterNewClaim()
        {
            bool isRunning = true;
            Console.Write("Would you like to enter a new claim(y/n)? ");
            string response = Console.ReadLine().ToLower();
            while (isRunning)
            {
                switch (response)
                {
                    case "y":
                    case "yes":
                        Claims newClaim = new Claims();
                        Console.Write("Enter the Claim ID: ");
                        newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the claim type (Car, Home, Theft): ");
                        string input = Console.ReadLine().ToLower();
                        newClaim.ClaimType = newClaim.GetCategory(input);
                        Console.WriteLine("Enter a claim description (30 characters or less):");
                        newClaim.Description = Console.ReadLine();
                        Console.Write("Amount of damage: ");
                        newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Date of Accident (month day year): ");
                        newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Date of Claim (month day year): ");
                        newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
                        Console.Clear();
                        return _claimRepo.AddToDirectory(newClaim);
                        break;
                    case "n":
                    case "no":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}
