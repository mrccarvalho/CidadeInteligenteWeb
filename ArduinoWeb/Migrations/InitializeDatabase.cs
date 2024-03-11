using ArduinoWeb.Data;
using ArduinoWeb.Models;

namespace ArduinoWeb.Migrations
{
    public class InitializeDatabase
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                using (var db = serviceProvider.GetService<ArduinoDbContext>())
                {
                    SeedDispositivos(db);
                    SeedLocalizacoes(db);
                    SeedEstacionamentos(db);
                    SeedRelatorioDispositivos(db);
                }
            }
        }

        private static void SeedDispositivos(ArduinoDbContext db)
        {
            if (!db.Dispositivos.Any())
            {
                db.Dispositivos.Add(new Dispositivo
                {
                    DispositivoId = 1,
                    Nome = "Arduino UNO - A",
                    Descricao = "Arduino UNO A"
                });
                db.Dispositivos.Add(new Dispositivo
                {
                    DispositivoId = 2,
                    Nome = "Arduino UNO - B",
                    Descricao = "Arduino UNO B"
                });
                db.SaveChanges();
            }
        }

        private static void SeedLocalizacoes(ArduinoDbContext db)
        {
            if (!db.Localizacoes.Any())
            {
                db.Localizacoes.AddAsync(new Localizacao
                {
                    LocalizacaoId = 1,
                    Nome = "Local A",
                    Descricao = "Data recolhidos do Arduino na Localização A"
                });
                db.Localizacoes.AddAsync(new Localizacao
                {
                    LocalizacaoId = 2,
                    Nome = "Local B",
                    Descricao = "Data recolhidos do Arduino na Localização B"
                });
                db.Localizacoes.AddAsync(new Localizacao
                {
                    LocalizacaoId = 3,
                    Nome = "Local C",
                    Descricao = "Data recolhidos do Arduino na Localização C"
                });
               
                db.SaveChanges();
            }
        }

        private static void SeedEstacionamentos(ArduinoDbContext db)
        {
            if (!db.Estacionamentos.Any())
            {
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 1,
                    Nome = "Estacionamento1",
                    Descricao = "Estacionamento1"
                });
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 2,
                    Nome = "Estacionamento2",
                    Descricao = "Estacionamento2"
                });
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 3,
                    Nome = "Estacionamento3",
                    Descricao = "Estacionamento3"
                });
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 4,
                    Nome = "Estacionamento4",
                    Descricao = "Estacionamento4"
                });
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 5,
                    Nome = "Estacionamento5",
                    Descricao = "Estacionamento5"
                });
                db.Estacionamentos.Add(new Estacionamento
                {
                    EstacionamentoId = 6,
                    Nome = "Estacionamento6",
                    Descricao = "Estacionamento6"
                });
                db.SaveChanges();
            }
        }

        private static void SeedRelatorioDispositivos(ArduinoDbContext db)
        {
            if (!db.RelatorioDispositivos.Any())
            {
                db.RelatorioDispositivos.Add(new RelatorioDispositivo
                {
                    RelatorioDispositivoId = 1,
                    DispositivoId = 1,
                    LocalizacaoId = 1,
                    Nome = "Arduino - 1",
                    Descricao = "Arduino UNO R2 - 1"
                });
                db.RelatorioDispositivos.Add(new RelatorioDispositivo
                {
                    RelatorioDispositivoId = 2,
                    DispositivoId = 2,
                    LocalizacaoId = 1,
                    Nome = "Arduino 2",
                    Descricao = "Arduino UNO R2 - 2"
                });
                db.SaveChanges();
            }
        }
}
}