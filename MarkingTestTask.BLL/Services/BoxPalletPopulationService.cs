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

        public BoxPalletPopulationService(
            IBoxModelRepository boxModelRepository,
            IPalletModelRepository palletModelRepository)
        {
            _boxModelRepository = boxModelRepository;
            _palletModelRepository = palletModelRepository;
        }

        // Метод для заполнения коробок и палет асинхронно.
        // Принимает информацию о компоновке продукта и список кодов продуктов.
        public async Task PopulateBoxesAndPalletsAsync(ProductLayoutInfoDto productLayoutInfo, List<string> codes)
        {
            int boxFormat = productLayoutInfo.BoxFormat;
            int palletFormat = productLayoutInfo.PalletFormat;

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

            await SaveEntitiesAsync(pallets, productLayoutInfo);
        }


        // Метод для сохранения палет в репозитории.
        private async Task SaveEntitiesAsync(List<PalletModel> pallets, ProductLayoutInfoDto productLayoutInfo)
        {
            foreach (var pallet in pallets)
            {
                // Добавляем палету в репозиторий.
                var addedPallet = await _palletModelRepository.AddAsync(pallet);
                await _palletModelRepository.SaveAsync();

                // Генерируем код для палеты на основе информации о компоновке продукта и ID палеты.
                addedPallet.Code = $"01{productLayoutInfo.Gtin}37{pallet.Boxes.Count}21{addedPallet.Id}";
                _palletModelRepository.Update(addedPallet);

                // Генерируем коды для коробок на палете.
                foreach (var box in pallet.Boxes)
                {
                    box.Code = $"01{productLayoutInfo.Gtin}37{box.Products.Count}21{box.Id}";
                    _boxModelRepository.Update(box);
                }
            }

            // Сохраняем изменения в репозитории.
            await _palletModelRepository.SaveAsync();
        }
    }

}
