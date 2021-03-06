﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Module.Core.Services;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Framework.Module.Core.Models;
using Framework.Infrastructure.Common.DataTable;
using Microsoft.AspNetCore.Http;
using Framework.Module.Core.ViewModels;

namespace Framework.Module.Core.Controllers
{
    [Route("api/roles")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public RoleController(ILogger<RoleController> logger, IMapper mapper, RoleManager<Role> roleManager, IRoleService roleService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._roleService = roleService;
            this._roleManager = roleManager;
        }

        [Route("data-table-paging")]
        [HttpPost]
        public IActionResult DataTablePaging([FromBody] DataTableRequest request)
        {
            return Ok(_roleService.DataTablePaging<RoleDataTableViewModel>(_roleService.Repository.Query(), request));
        }

        [Route("find/{id}")]
        [HttpGet]
        public IActionResult Find(long id)
        {
            return Ok(_roleService.Find(id));
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var original = _mapper.Map<Role>(viewModel);
            _roleService.Add(original);
            return CreatedAtRoute("find", original.Id);
        }

        [Route("edit/{id}")]
        [HttpPut]
        public IActionResult Edit(long id, RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != viewModel.Id)
            {
                return BadRequest();
            }
            try
            {
                var original = _roleService.Find(id);
                if (original == null)
                {
                    return NotFound();
                }
                original = _mapper.Map(viewModel, original);
                _roleService.Update(original);
                return Ok(original);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var original = _roleService.Find(id);
            if (original == null)
            {
                return NotFound();
            }
            _roleService.Delete(original);
            return Ok(original);
        }
    }
}
