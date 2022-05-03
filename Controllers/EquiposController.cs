using Apuestas_AWS.Models;
using Apuestas_AWS.Repositories;
using Apuestas_AWS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Apuestas_AWS.Controllers
{
    public class EquiposController : Controller
    {
        public RepositoryApuestas repo;
        public ServiceAWSS3 service;

        public EquiposController(RepositoryApuestas repo, ServiceAWSS3 service)
        {
            this.service = service;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }

        public IActionResult Jugadores(int idequipo)
        {
            List<Jugador> jugadores = this.repo.GetJugadoresEquipo(idequipo);
            return View(jugadores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(string nombre, string posicion, int idequipo, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, file.FileName);
            }
            this.repo.InsertarJugador(nombre, posicion, idequipo, file.FileName);
            return RedirectToAction("Index");
        }

        public IActionResult Apuestas()
        {
            List<Apuesta> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }

        public IActionResult CreateApuesta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateApuesta(string usuario, int idEquipoLocal, int idEquipoVisitante, int golesEquipoLocal, int golesEquipoVisitante)
        {
            this.repo.InsertarApuesta(usuario, idEquipoLocal, idEquipoVisitante, golesEquipoLocal, golesEquipoVisitante);
            return RedirectToAction("Apuestas");
        }

    }
}
