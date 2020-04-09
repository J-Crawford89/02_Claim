using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim
{
    public class Claims
    {
        public enum Category { Car, Home, Theft }
        public int ClaimID { get; set; }
        public Category ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeToClaim = DateOfClaim - DateOfIncident;
                double totalDays = timeToClaim.TotalDays;
                double floorDays = Math.Floor(totalDays);
                int days = Convert.ToInt32(floorDays);

                return days <= 30;
            }
        }
        public Category GetCategory(string input)
        {
            bool incorrectInput = true;
            while(incorrectInput)
            {
                switch(input.ToLower())
                {
                    case "car":
                        incorrectInput = false;
                        return Category.Car;
                    case "home":
                        incorrectInput = false;
                        return Category.Home;
                    case "theft":
                        incorrectInput = false;
                        return Category.Theft;
                    default:
                        Console.WriteLine("Incorrect input. Please try again.");
                        input = Console.ReadLine().ToLower();
                        break;
                }
            }
            return Category.Car;
        }
        public Claims() { }
        public Claims(int claimID, Category claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
