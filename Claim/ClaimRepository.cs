using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim
{
    public class ClaimRepository
    {
        private readonly List<Claims> _claimDirectory = new List<Claims>();
        public void ShowAllClaims()
        {
            Console.Clear();
            Console.WriteLine($"{"ClaimID",-8}|{"Type",-6}|{"Description",-30}|{"Amount",-10}|{"Date of Accident",-17}|{"Date of Claim",-14}|{"IsValid",7}\n" +
                $"--------------------------------------------------------------------------------------------------");
            foreach (Claims claim in _claimDirectory)
            {
                Console.WriteLine($"{claim.ClaimID,-8}|{claim.ClaimType,-6}|{claim.Description,-30}|{claim.ClaimAmount,-10}|{claim.DateOfIncident.Date.ToString("MM/dd/yy"),-17}|{claim.DateOfClaim.Date.ToString("MM/dd/yy"),-14}|{claim.IsValid,7}");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public bool AddToDirectory(Claims claimToAdd)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(claimToAdd);

            return startingCount < _claimDirectory.Count;
        }
        public void DealWithClaim()
        {
            Claims claim = _claimDirectory[0];
            Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                $"ClaimID: {claim.ClaimID}\n" +
                $"Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"Date of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is Vald: {claim.IsValid}\n\n" +
                $"Do you want to deal with this claim now(y/n)?");
            string response = Console.ReadLine().ToLower();
            bool invalidResponse = true;
            while (invalidResponse)
            {
                switch (response)
                {
                    case "y":
                    case "yes":
                        invalidResponse = false;
                        bool wasRemoved = RemoveTopClaim();
                        if(wasRemoved)
                        {
                            Console.WriteLine("Claim successfully handled");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "n":
                    case "no":
                        invalidResponse = false;
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        public bool RemoveTopClaim()
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.RemoveAt(0);
            return startingCount > _claimDirectory.Count;
        }
    }
}
