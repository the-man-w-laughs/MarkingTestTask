using AutoMapper;
using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;
using Newtonsoft.Json;
using System.IO;

namespace MarkingTestTask.BLL.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly IMissionModelRepository _missionModelRepository;
        private readonly IMapper _mapper;

        public LayoutService(IMissionModelRepository missionModelRepository, IMapper mapper)
        {
            _missionModelRepository = missionModelRepository;
            _mapper = mapper;
        }

        public async Task CreateLayoutJsonFileAsync(int missionId)
        {
            var mission = await _missionModelRepository.GetMissionById(missionId);

            if (mission == null)
            {
                throw new Exception($"Mission with ID {missionId} does not exist.");
            }

            var missionJsonDto = _mapper.Map<MissionJsonDto>(mission);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(missionJsonDto, Formatting.Indented, settings);

            string dateAndTime = DateTime.Now.ToString("yyMMdd_HHmm");
            string filename = $"{mission.Gtin}_result_file_{dateAndTime}.json";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, filename);
            File.WriteAllText(filePath, json);
        }
    }
}
