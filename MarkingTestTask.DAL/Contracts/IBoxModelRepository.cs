﻿using MarkingTestTask.DAL.BaseRepository;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.DAL.Contracts
{
    public interface IBoxModelRepository : IBaseRepository<BoxModel>
    {
        Task<List<BoxModel>> GetAllByMissionId(int missionId);
    }
}
