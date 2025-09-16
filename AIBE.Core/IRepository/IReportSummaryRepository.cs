using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReportSummary;
using AIBE.Core.Models;

namespace AIBE.Core.IRepository
{
    public interface IReportSummaryRepository
    {
        Task<List<ReportSummaryDto>> GetAll();

        Task<Reportsummary?> GetByIdAsync(int id);

        Task<Reportsummary> CreateAsync(Reportsummary reportsummary);

        Task<bool> DeleteAsync(int id);

    }
}