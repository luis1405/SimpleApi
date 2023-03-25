using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infraestructure.Repository;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;

namespace Api.Controllers
{
    public class HumanoController : Controller
    {
        private readonly IHumanoRepository _humanoRepository;

        public HumanoController(IHumanoRepository humanoRepository)
        {
            _humanoRepository = humanoRepository;
        }

        // GET: HumanoController
        public async Task<ActionResult<List<HumanoDTO>>> Index()
        {
            return await _humanoRepository.Listar();
        }

        // GET: HumanoController/Details/5
        public async Task<ActionResult<HumanoDTO>> Details(int id)
        {
            return await _humanoRepository.SeleccionarPorID(id);
        }

        // GET: HumanoController/Create
        public ActionResult Create()
        {
            return Ok(new HumanoDTO());
        }

        // POST: HumanoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HumanoDTO humano)
        {
            try
            {
                int result = _humanoRepository.Agregar(humano).Result;
                return result == 0 ? BadRequest() : Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: HumanoController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HumanoDTO humano)
        {
            try
            {
                int result = _humanoRepository.Editar(humano).Result;
                return result == 0 ? BadRequest() : Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
