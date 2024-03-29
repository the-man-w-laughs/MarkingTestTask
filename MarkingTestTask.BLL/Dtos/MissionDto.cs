﻿namespace MarkingTestTask.BLL.Dtos
{
    public class MissionDto
    {
        public int MissionId { get; set; }
        public string Volume { get; set; } = string.Empty;
        public int BoxFormat { get; set; }
        public int PalletFormat { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gtin { get; set; } = string.Empty;
    }
}
