﻿namespace ArduinoWeb.ViewModels
{
    public class MedicaoVm
    {
        public DateTime? DataMedicao { get; set; }
        public string NomeLocalizacao { get; set; }
        public decimal? Estacionamento1 { get; set; }
        public decimal? Estacionamento2 { get; set; }
        public decimal? Estacionamento3 { get; set; }
        public decimal? Estacionamento4 { get; set; }
        public decimal? Estacionamento5 { get; set; }
        public decimal? Estacionamento6 { get; set; }

        public string DateOnlyString => DataMedicao?.ToString("yyyy-MM-dd") ?? string.Empty;
        public string TimeOnlyString => DataMedicao?.ToString("hh:mm:ss tt") ?? string.Empty;


        public string Estacionamento1String => (Estacionamento1 != null) ? Estacionamento1.Value.ToString("###.0") : "0.0";
        public string Estacionamento2String => (Estacionamento2 != null) ? Estacionamento2.Value.ToString("###.0") : "0.0";
        public string Estacionamento3String => (Estacionamento3 != null) ? Estacionamento3.Value.ToString("###.0") : "0.0";
        public string Estacionamento4String => (Estacionamento4 != null) ? Estacionamento4.Value.ToString("###.0") : "0.0";
        public string Estacionamento5String => (Estacionamento5 != null) ? Estacionamento5.Value.ToString("###.0") : "0.0";
        public string Estacionamento6String => (Estacionamento6 != null) ? Estacionamento6.Value.ToString("###.0") : "0.0";
    }
}
