using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Frequency;
using AIBE.Core.DTOs.FrequencyDetail;
using AIBE.Core.DTOs.Position;
using AIBE.Core.DTOs.Task;
using AIBE.Core.Models;

namespace AIBE.Core.IRepository
{
    public interface ITaskRepository
    {
        Task<TaskRequestDto> CreateTask(TaskRequestDto taskRequestDto, FrequencyRequestDto frequencyRequestDto, Frequencydetail frequencydetail);
        Task<TaskRequestDto> UpdateTask(int id,TaskRequestDto taskRequestDto);
        Task<TaskRequestDto> DeleteTask(int taskId);
        Task<List<TaskSearchDto>> getsearch(TaskSearchDto taskSearch);
    }
}
