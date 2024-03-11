using ArduinoWeb.Data;
using ArduinoWeb.Models;
using ArduinoWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace ArduinoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArduinoDbContext _context;

        public HomeController(ILogger<HomeController> logger, ArduinoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Home page - Lista dispositivos, Localizacoes
        /// últimas 10 leituras
        /// leituras para um dado dispositivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Index(int? id = null)
        {
            var vm = new DispositivoVm { RelatorioDispositivoId = id };
            RelatorioDispositivo dispositivo = null;

            // define a lista de dispositivos e Localizacoes para mostrar
            if (_context.RelatorioDispositivos.Any())
            {
                vm.RelatorioDispositivos = _context.RelatorioDispositivos.ToList();

                // devolve o primeiro dispositivo 
                dispositivo = vm.RelatorioDispositivos.First();
            }

            if (_context.Localizacoes.Any())
            {
                vm.Localizacoes = _context.Localizacoes.ToList();
            }

            // carregar dispositivo
            if (id.HasValue)
            {
                dispositivo = _context.RelatorioDispositivos.FirstOrDefault(d => d.RelatorioDispositivoId == id.Value);
            }

            if (dispositivo != null)
            {
                vm.RelatorioDispositivoId = dispositivo.RelatorioDispositivoId;
                vm.TipoNome = dispositivo.Nome;
                vm.LocalizacaoNome = dispositivo.Localizacao.Nome;
                vm.LocalIp = dispositivo.UltimoIpAddress;
                vm.LastSet = MaisRecentes(dispositivo.RelatorioDispositivoId);
            }

            return View(vm);
        }

        /// <summary>
        /// devolve leituras mais recentes de um dispositivo específico
        /// </summary>
        /// <param name="relatorioDispositivoId"></param>
        /// <returns></returns>
        public MedicaoVm MaisRecentes(int relatorioDispositivoId)
        {
            var recente = new MedicaoVm();

            var last6 = _context.Medicoes
                .Where(m => m.RelatorioDispositivoId == relatorioDispositivoId)
                .Select(m => m).Include(l => l.Localizacao).Distinct().
                OrderByDescending(m => m.DataMedicao).Take(3).ToList();

            if (last6.Any())
            {
                var estacionamento1 = last6.FirstOrDefault(m => m.EstacionamentoId == 1);
                var estacionamento2 = last6.FirstOrDefault(m => m.EstacionamentoId == 2);
                var estacionamento3 = last6.FirstOrDefault(m => m.EstacionamentoId == 3);
                var estacionamento4 = last6.FirstOrDefault(m => m.EstacionamentoId == 3);
                var estacionamento5 = last6.FirstOrDefault(m => m.EstacionamentoId == 3);
                var estacionamento6 = last6.FirstOrDefault(m => m.EstacionamentoId == 3);

                if (estacionamento1 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento1 = estacionamento1.ValorLido;
                }
                if (estacionamento2 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento2 = estacionamento1.ValorLido;
                }
                if (estacionamento3 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento3 = estacionamento1.ValorLido;
                }
                if (estacionamento4 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento4 = estacionamento1.ValorLido;
                }
                if (estacionamento5 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento5 = estacionamento1.ValorLido;
                }
                if (estacionamento6 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento6 = estacionamento1.ValorLido;
                }


            }

            return recente;
        }

        /// <summary>
        /// devolve leituras
        /// </summary>
        /// <returns></returns>
        public IActionResult MaisRecentesPorLocal(int? localizacaoId = null)
        {
            var recente = new MedicaoVm();

            var last6 = _context.Medicoes
                .Where(m => m.LocalizacaoId == localizacaoId)
                .Select(m => m).Include(l => l.Localizacao).Distinct().
                OrderByDescending(m => m.DataMedicao).Take(3).ToList();

            if (last6.Any())
            {
                var estacionamento1 = last6.FirstOrDefault(m => m.EstacionamentoId == 1);
                var estacionamento2 = last6.FirstOrDefault(m => m.EstacionamentoId == 2);
                var estacionamento3 = last6.FirstOrDefault(m => m.EstacionamentoId == 3);
                var estacionamento4 = last6.FirstOrDefault(m => m.EstacionamentoId == 4);
                var estacionamento5 = last6.FirstOrDefault(m => m.EstacionamentoId == 5);
                var estacionamento6 = last6.FirstOrDefault(m => m.EstacionamentoId == 6);

                if (estacionamento1 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento1 = estacionamento1.ValorLido;
                }
                if (estacionamento2 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento2 = estacionamento1.ValorLido;
                }
                if (estacionamento3 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento3 = estacionamento1.ValorLido;
                }
                if (estacionamento4 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento4 = estacionamento1.ValorLido;
                }
                if (estacionamento5 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento5 = estacionamento1.ValorLido;
                }
                if (estacionamento6 != null)
                {
                    recente.DataMedicao = estacionamento1.DataMedicao;
                    recente.Estacionamento6 = estacionamento1.ValorLido;
                }
            }

            return View(recente);
        }

        /// <summary>
        /// devolve leituras
        /// </summary>
        /// <returns></returns>
        public IActionResult TodasPorLocal(int localizacaoId)
        {
            List<Medicao> recente = new List<Medicao>();

            recente = _context.Medicoes
                .Where(m => m.LocalizacaoId == localizacaoId)
                .Select(m => m).Include(l => l.Localizacao).
                Include(t => t.Estacionamento).
                OrderByDescending(m => m.DataMedicao).ToList();

           

            return View(recente);
        }


        /// <summary>
        /// Show view allowing add of a location
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddLocation()
        {
            return View(new LocalizacaoHandlerVm());
        }


        /// <summary>
        /// Do the work of adding a location
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddLocation(LocalizacaoHandlerVm model)
        {
            if (@ModelState.IsValid)
            {
                // check if name is in use
                if (_context.Localizacoes.Any(l => l.Nome.Equals(model.NomeLocalizacao)))
                {
                    model.Sucesso = false;
                    model.Mensagem = "Name is in use";
                }
                else
                {
                    // didn't use an identity seed for location so I have to manually increment
                    var addedId = _context.Localizacoes.Max(l => l.LocalizacaoId) + 1;
                    var addedLoc = new Localizacao
                    { LocalizacaoId = addedId, Nome = model.NomeLocalizacao, Descricao = model.LocalizacaoDescricao };

                    _context.Localizacoes.Add(addedLoc);
                    _context.SaveChanges();

                    // will not assume user wants to move a device to this location yet so just head back to home page
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }


        /// <summary>
        /// Çoce um dispositivo para uma nova localização
        /// </summary>
        /// <param name="relatorioDispositivoId"></param>
        /// <param name="localizacaoId"></param>
        /// <returns></returns>
        public ActionResult AlteraLocalizacao(int relatorioDispositivoId, int localizacaoId)
        {
            var model = new LocalizacaoHandlerVm { RelatorioDispositivoId = relatorioDispositivoId, Sucesso = false };
            var device = _context.RelatorioDispositivos.Include(t => t.Dispositivo).FirstOrDefault(d => d.RelatorioDispositivoId == relatorioDispositivoId);
            var location = _context.Localizacoes.FirstOrDefault(l => l.LocalizacaoId == localizacaoId);

            if (device == null) { model.Mensagem = $"Device with ID {relatorioDispositivoId} not found"; }
            else if (location == null) { model.Mensagem = $"Location with ID {localizacaoId} not found"; }
            else
            {
                device.LocalizacaoId = location.LocalizacaoId;
                _context.RelatorioDispositivos.Attach(device);
                _context.Entry(device).State = EntityState.Modified;
                _context.SaveChanges();

                model.DispositivoNome = device.Dispositivo.Nome;
                model.NomeLocalizacao = location.Nome;
                model.Sucesso = true;
            }

            return View(model);
        }


        /// <summary>
        /// Method that receives the three values from the device and posts them to the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="estacionamento1"></param>
        /// <param name="estacionamento2"></param>
        /// <param name="estacionamento3"></param>
        /// <param name="estacionamento4"></param>
        /// <param name="estacionamento5"></param>
        /// <param name="estacionamento6"></param>
        /// <returns></returns>
        public ActionResult PostData(int id, string ip, decimal? estacionamento1,
            decimal? estacionamento2, decimal? estacionamento3, decimal? estacionamento4,
            decimal? estacionamento5, decimal? estacionamento6)
        {
            var results = "Sucesso";
            var reported = DateTime.Now;

         

            try
            {
                var device = _context.RelatorioDispositivos.FirstOrDefault(d => d.RelatorioDispositivoId == id);
                var est1 = _context.Estacionamentos.FirstOrDefault(d => d.EstacionamentoId == 1);

                if (device == null)
                {
                    results = "Dispositivo desconhecido";
                }
                else
                {
                    // atualizar o ip address primeiro
                    device.UltimoIpAddress = ip;

                    if (estacionamento1.HasValue)
                    {
                        est1.Estado = true ;
                        // Adiciona Medição/Leitura do estacionamento 1
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento1,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento1.Value,
                            DataMedicao = reported
                        });
                    }

                    if (estacionamento2.HasValue)
                    {
                        // Adiciona Medição/Leitura do estacionamento 2
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento2,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento2.Value,
                            DataMedicao = reported
                        });
                    }
                    if (estacionamento1.HasValue)
                    {
                        // Adiciona Medição/Leitura do estacionamento 3
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento3,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento3.Value,
                            DataMedicao = reported
                        });
                    }
                    if (estacionamento4.HasValue)
                    {
                        // Adiciona Medição/Leitura do estacionamento 4
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento4,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento1.Value,
                            DataMedicao = reported
                        });
                    }
                    if (estacionamento5.HasValue)
                    {
                        // Adiciona Medição/Leitura do estacionamento 5
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento5,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento5.Value,
                            DataMedicao = reported
                        });
                    }
                    if (estacionamento6.HasValue)
                    {
                        // Adiciona Medição/Leitura do estacionamento 1
                        _context.Medicoes.Add(new Medicao
                        {
                            EstacionamentoId = (int)TipoMedicaoEnum.Estacionamento6,
                            RelatorioDispositivoId = device.RelatorioDispositivoId,
                            LocalizacaoId = device.LocalizacaoId,
                            ValorLido = estacionamento6.Value,
                            DataMedicao = reported
                        });
                    }


                    // gravar
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                results = "Erro: " + ex.Message;
            }

            return Content(results);
        }


        public IActionResult Todas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
