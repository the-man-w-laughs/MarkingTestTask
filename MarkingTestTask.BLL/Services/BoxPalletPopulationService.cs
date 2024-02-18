using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Dtos;
using MarkingTestTask.DAL.Contracts;
using MarkingTestTask.DAL.Models;

namespace MarkingTestTask.BLL.Services
{
    public class BoxPalletPopulationService : IBoxPalletPopulationService
    {
        private readonly IBoxModelRepository _boxModelRepository;
        private readonly IPalletModelRepository _palletModelRepository;
        private readonly IMissionModelRepository _missionModelRepository;
        private readonly IProductModelRepository _productModelRepository;

        public BoxPalletPopulationService(
            IBoxModelRepository boxModelRepository,
            IPalletModelRepository palletModelRepository,
            IMissionModelRepository missionModelRepository,
            IProductModelRepository productModelRepository)
        {
            _boxModelRepository = boxModelRepository;
            _palletModelRepository = palletModelRepository;
            _missionModelRepository = missionModelRepository;
            _productModelRepository = productModelRepository;
        }

        // Метод для заполнения коробок и палет асинхронно.
        // Принимает информацию о компоновке продукта и список кодов продуктов.
        public async Task PopulateBoxesAndPalletsAsync(MissionDto missionDto, List<string> codes)
        {
            var missionModel = new MissionModel()
            {
                MissionId = missionDto.MissionId,
                Volume = missionDto.Volume,
                BoxFormat = missionDto.BoxFormat,
                PalletFormat = missionDto.PalletFormat,
                Name = missionDto.Name,
                Gtin = missionDto.Gtin
            };

            int boxFormat = missionDto.BoxFormat;
            int palletFormat = missionDto.PalletFormat;

            var products = codes.Select(code => new ProductModel
            {
                Code = code
            }).ToList();

            var boxes = new List<BoxModel>();
            var pallets = new List<PalletModel>();

            // Итерируем по списку продуктов, формируя коробки и палеты.
            for (int i = 0; i < products.Count; i += boxFormat)
            {
                // Выбираем группу продуктов для текущей коробки.
                var productGroup = products.Skip(i).Take(boxFormat).ToList();
                var box = new BoxModel { Products = productGroup };
                boxes.Add(box);

                // Если количество сформированных коробок достигло формата палеты
                // или достигнут конец списка продуктов, добавляем палету в список.
                if (boxes.Count == palletFormat || i + boxFormat >= products.Count)
                {
                    var pallet = new PalletModel { Boxes = boxes };
                    pallets.Add(pallet);
                    boxes = new List<BoxModel>();
                }
            }

            await SaveEntitiesAsync(pallets, missionModel);
        }


        // Метод для сохранения палет в репозитории.
        private async Task SaveEntitiesAsync(List<PalletModel> pallets, MissionModel missionModel)
        {
            var mission = await _missionModelRepository.GetAsync(mission => mission.MissionId == missionModel.MissionId);
            if (mission == null)
            {
                mission = await _missionModelRepository.AddAsync(missionModel);
                await _missionModelRepository.SaveAsync();
            }

            foreach (var pallet in pallets)
            {
                SetMissionIdForEntities(pallet, mission.Id);

                var addedPallet = await _palletModelRepository.AddAsync(pallet);
                await _palletModelRepository.SaveAsync();

                // Генерируем код для палеты на основе информации о компоновке продукта и ID палеты.                
                addedPallet.Code = GenerateCode(missionModel.Gtin, pallet.Boxes.Count, addedPallet.Id);
                _palletModelRepository.Update(addedPallet);

                // Генерируем коды для коробок на палете.
                foreach (var box in pallet.Boxes)
                {
                    box.Code = GenerateCode(missionModel.Gtin, box.Products.Count, box.Id);
                    _boxModelRepository.Update(box);
                }
            }

            // Сохраняем изменения в репозитории.
            await _palletModelRepository.SaveAsync();
        }

        private void SetMissionIdForEntities(PalletModel pallet, int missionId)
        {
            pallet.MissionId = missionId;
            foreach (var box in pallet.Boxes)
            {
                box.MissionId = missionId;
                foreach (var product in box.Products)
                {
                    product.MissionId = missionId;
                }
            }
        }

        private string GenerateCode(string gtin, int count, int id)
        {
            return $"01{gtin}37{count}21{id}";
        }
    }

}
