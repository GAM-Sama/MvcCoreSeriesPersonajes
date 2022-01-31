using Microsoft.AspNetCore.Mvc;
using MvcCoreSeriesPersonajes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSeriesPersonajes.Controllers
{
    public class SeriesController : Controller
    {
        private ServiceSeries service;
        public SeriesController(ServiceSeries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Series()
        {
            return View(await this.service.GetSeriesAsync());
        }
        public async Task<IActionResult> Personajes()
        {
            return View(await this.service.GetPersonajesAsync());
        }
        public async Task<IActionResult> DetailSerie(int idserie)
        {
            return View(await this.service.FindSerieAsync(idserie));
        }
        public async Task<IActionResult> DetailPersonaje(int idpersonaje)
        {
            return View(await this.service.FindPersonajeAsync(idpersonaje));
        }
        public async Task<IActionResult> PersonajesSerie(int idpersonaje, int idserie)
        {
            return View(await this.service.FindPersonajesSerieAsync(idpersonaje,idserie));
        }
        public async Task<IActionResult> UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            await this.service.UpdatePersonajeAsync(idpersonaje, idserie);
            return RedirectToAction("Index");
        }
    }
}
