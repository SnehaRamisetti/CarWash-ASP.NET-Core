using CaseStudyOnCarWash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
     public interface IPackage
    {
        Task<List<PackageDetails>> GetAllPackageDetails();

        Task<PackageDetails> GetPackageById(int id);

        Task<PackageDetails> AddPackage(PackageDetails package);

        Task<PackageDetails> UpdatePackage(int id, PackageDetails package);

        Task DeletePackage(int id);
    }
}
