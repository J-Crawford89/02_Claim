using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claim;

namespace ClaimTests
{
    [TestClass]
    public class RepoTests
    {
        ClaimRepository _claimRepo = new ClaimRepository();

        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBool()
        {
            Claims newClaim = new Claims();

            bool wasAdded = _claimRepo.AddToDirectory(newClaim);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void RemoveTopClaim_ShouldGetCorrectBool()
        {
            Claims newClaim = new Claims();
            _claimRepo.AddToDirectory(newClaim);
            bool wasRemoved = _claimRepo.RemoveTopClaim();

            Assert.IsTrue(wasRemoved);
        }
    }
}
